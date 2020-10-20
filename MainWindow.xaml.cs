using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;

namespace Beatbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private static BackgroundWorker worker;

        private static int maxDamageValueForLevel = 100;

        private static int damagePerHit = 10;
        private static int baseAttackRate = 2500;       // in millisec
        private static double baseCritChance = 5.0;

        private static int currentXP = 0;
        private static int currentLevel = 0;
        private static int currentAP = 1;
        private static int currentCR = 1;
        private static int currentHR = 1;
        private static int currentDamagePerHit = damagePerHit;
        private static int currentAttackRate = baseAttackRate;
        private static double currentCritChance = 5.0;
        private static int currentRecord = 0;

        private static int availablePoints = 0;
        private static int overdraft = 0;

        private static double convertRatioAP = 1.15;    // increases the damage
        private static double convertRatioCR = 1.1;     // increases crit chance
        private static double convertRatioHR = 1.1;     // decreases attack rate

        public MainWindow()
        {
            InitializeComponent();
        }

        private int CalcDamageValue()
        {
            Random random = new Random();

            int minDmg = (int) (currentDamagePerHit * 0.75);
            int returned = random.Next(minDmg, currentDamagePerHit + 1);

            currentCritChance = baseCritChance * Math.Pow(convertRatioCR, currentCR - 1);
            double check = random.NextDouble()*100+1;
            if (check <= currentCritChance)
            {
                returned *= 2;
            }

            return returned;
        }

        /// <summary>
        /// Executes after window is rendered. It is required to update the progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            InitWorker();
            HideIncreaseButtons();
            // init UI
            ValueAP.Content = currentAP;
            ValueCR.Content = currentCR;
            ValueHR.Content = currentHR;
            AttackRateValue.Content = currentAttackRate/1000.0;
        }

        private void InitWorker()
        {
            System.Diagnostics.Debug.WriteLine("Worker started...");

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for the BackgroundWorker tasks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Doing work");
            int dmg = 0;
            currentXP = Math.Max(0, overdraft);
            while(currentXP < maxDamageValueForLevel)
            {
                // if cancelation is needed, see "completed" method
                // call worker.CancelAsync() from UI to set CancellationPending
                if ((sender as BackgroundWorker).CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                dmg = CalcDamageValue();
                currentXP += dmg;
                System.Diagnostics.Debug.WriteLine("dmg: {0}, sum: {1}", dmg, currentXP);
                overdraft = currentXP - maxDamageValueForLevel;
                // must be a percentage
                int percentage = (int)(100 * currentXP / (double)maxDamageValueForLevel);
                (sender as BackgroundWorker).ReportProgress(percentage, dmg);

                Thread.Sleep(currentAttackRate);
            }
        }

        /// <summary>
        /// Used to reflect any changes that happen due to the BackgroundWorker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("progress changed");
            XPBar.Value = e.ProgressPercentage;
            UpdateDPS();
            UpdateMaxDamage((int)e.UserState);
            AppendToLog((int)e.UserState, "\n");
        }

        /// <summary>
        /// Executed when the BackgroundWorker finished.
        /// When it finishes due to user input or an error, it disposes resources.
        /// When finishing normally, it hides buttons and updates level constraints and progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Worker completed.");
            
            if (e.Cancelled)    // manual cancellation
            {
                //worker.CancelAsync();
                (sender as BackgroundWorker).Dispose();
            }
            else if (e.Error != null)   // error occured
            {
                //worker.CancelAsync();
                (sender as BackgroundWorker).Dispose();
            }
            else    // normal continuation
            {
                // update calculations and UI
                ShowIncreaseButtons();
                UpdateLevelConstraints();
                UpdateProgressBar();

                availablePoints++;

                if (overdraft > 0)
                {
                    currentXP = overdraft;
                }
                else
                {
                    currentXP = 0;
                }

                (sender as BackgroundWorker).RunWorkerAsync();
            }
        }

        /// <summary>
        /// Updates attack rate with a given formula.
        /// </summary>
        private void UpdateAttackRate()
        {
            currentAttackRate = (int) (baseAttackRate * Math.Pow(convertRatioHR, currentHR - 1));
            AttackRateValue.Content = currentAttackRate / 1000.0;
        }

        /// <summary>
        /// Updates constraints for min and max damage for the level-up.
        /// </summary>
        private void UpdateLevelConstraints()
        {
            currentLevel += 1;
            maxDamageValueForLevel = maxDamageValueForLevel * currentLevel;
        }

        /// <summary>
        /// Updates minimum and maximum damage possible.
        /// </summary>
        private void UpdateDamagePerHit()
        {
            currentDamagePerHit = (int) (currentDamagePerHit * convertRatioAP);
            System.Diagnostics.Debug.WriteLine("currentMinDamage: {0}", (int)(currentDamagePerHit * 0.75));
            System.Diagnostics.Debug.WriteLine("currentMaxDamage: {0}", currentDamagePerHit);
        }

        /// <summary>
        /// Used to update the progress bar on the UI based on new data.
        /// Invoke only after maxDamageValueForLevel had been updated.
        /// </summary>
        private void UpdateProgressBar()
        {
            XPBar.Value = (int)(100*currentXP/(double)maxDamageValueForLevel);
        }

        /// <summary>
        /// Function to update the damage per second. It is calculated entirely on average damage
        /// including critical hit chance.
        /// </summary>
        private void UpdateDPS()
        {
            CurrentDamageValue.Content =
                currentCritChance * currentDamagePerHit * 1.75 / (2.0 * currentAttackRate / 1000);
        }

        /// <summary>
        /// Checks if the given value for damage is higher than the current record and updates accordingly.
        /// </summary>
        /// <param name="dmg">Value to be compared with current record.</param>
        private void UpdateMaxDamage(int dmg)
        {
            if (dmg > currentRecord)
            {
                currentRecord = dmg;
                MaxDamageValue.Content = currentRecord;
            }
        }

        /// <summary>
        /// Event handler to increase attack power.
        /// </summary>
        /// <param name="sender">Button object that fired the event.</param>
        /// <param name="e"></param>
        private void IncreaseAP(object sender, RoutedEventArgs e)
        {
            if (availablePoints > 0)
            {
                currentAP++;
                availablePoints--;
                ValueAP.Content = currentAP;
                UpdateDamagePerHit();
                if (availablePoints == 0)
                {
                    HideIncreaseButtons();
                }
                AppendToLog("Attack Power upgraded by 1.", "\n");
            }
            
        }

        /// <summary>
        /// Event handler to increase critical rating.
        /// </summary>
        /// <param name="sender">Button object that fired the event.</param>
        /// <param name="e"></param>
        private void IncreaseCR(object sender, RoutedEventArgs e)
        {
            if (availablePoints > 0)
            {
                currentCR++;
                availablePoints--;
                ValueCR.Content = currentCR;
                if (availablePoints == 0)
                {
                    HideIncreaseButtons();
                }
                AppendToLog("Critical Strike Rating upgraded by 1.", "\n");
            }
        }

        /// <summary>
        /// Event handler to increase haste rating.
        /// </summary>
        /// <param name="sender">Button object that fired the event.</param>
        /// <param name="e"></param>
        private void IncreaseHR(object sender, RoutedEventArgs e)
        {
            if (availablePoints > 0)
            {
                currentHR++;
                availablePoints--;
                ValueHR.Content = currentHR;
                UpdateAttackRate();
                if (availablePoints == 0)
                {
                    HideIncreaseButtons();
                }
                AppendToLog("Haste Rating upgraded by 1.", "\n");
            }
        }

        private void HideIncreaseButtons()
        {
                IncrBttnAP.Visibility = Visibility.Hidden;
                IncrBttnCR.Visibility = Visibility.Hidden;
                IncrBttnHR.Visibility = Visibility.Hidden;
                IncrBttnAP.IsEnabled = false;
                IncrBttnCR.IsEnabled = false;
                IncrBttnHR.IsEnabled = false;
        }

        private void ShowIncreaseButtons()
        {
            IncrBttnAP.Visibility = Visibility.Visible;
            IncrBttnCR.Visibility = Visibility.Visible;
            IncrBttnHR.Visibility = Visibility.Visible;
            IncrBttnAP.IsEnabled = true;
            IncrBttnCR.IsEnabled = true;
            IncrBttnHR.IsEnabled = true;
        }

        private void AppendToLog(Object text, String seperator)
        {
            StringBuilder sb = new StringBuilder(Log.Text);
            sb.Append(text);
            sb.Append(seperator);
            Log.Text = sb.ToString();
            ScrollViewer.ScrollToEnd();
        }

        private void StartBeatbox(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
                AppendToLog("Starting to hit stuff...", "\n");
            }
        }

        private void StopBeatbox(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                AppendToLog("Enough hitting, going to stop now.", "\n");
            }
        }
    }
}
