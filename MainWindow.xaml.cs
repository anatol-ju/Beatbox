using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beatbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private static BackgroundWorker worker;

        private static int minDamageValueForLevel = 0;
        private static int maxDamageValueForLevel = 10;

        private static int minDamage = 2;
        private static int maxDamage = 5;
        private static int baseAttackRate = 2500;       // in millisec
        private static double baseCritChance = 5.0;

        private static int currentXP = 0;
        private static int currentLevel = 0;
        private static int currentAP = 1;
        private static int currentCR = 1;
        private static int currentHR = 1;
        private static int currentMinDamage = minDamage;
        private static int currentMaxDamage = maxDamage;
        private static int currentAttackRate = baseAttackRate;

        private static double convertRatioAP = 1.41;    // increases the damage
        private static double convertRatioCR = 1.1;     // increases crit chance
        private static double convertRatioHR = 1.05;    // decreases attack rate

        public MainWindow()
        {
            InitializeComponent();
        }

        private int CalcDamageValue()
        {
            Random random = new Random();

            int returned = random.Next(currentMinDamage, currentMaxDamage + 1);

            double critChance = baseCritChance + convertRatioCR * Math.Log(currentCR);
            int check = random.Next(1, 101);
            if (check <= critChance)
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
            //StartWorker();
            HideIncreaseButtons();
            // init UI
            AttackRateValue.Content = currentAttackRate/1000.0;
        }

        private void StartWorker()
        {
            System.Diagnostics.Debug.WriteLine("Worker started...");

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
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
            int sum = Math.Max(minDamageValueForLevel, currentXP);
            while(sum < maxDamageValueForLevel)
            {
                // if cancelation is needed, see "completed" method
                // call worker.CancelAsync() from UI to set CancellationPending
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    currentXP = sum;
                    return;
                }
                dmg = CalcDamageValue();
                sum += dmg;
                System.Diagnostics.Debug.WriteLine("dmg: {0}, sum: {1}", dmg, sum);
                // must be a percentage
                worker.ReportProgress((int)(100 * sum / (double)maxDamageValueForLevel), dmg);

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
            StringBuilder sb = new StringBuilder(Log.Text);
            sb.Append((int)e.UserState);
            sb.Append("\n");
            Log.Text = sb.ToString();
        }

        /// <summary>
        /// Executed when the BackgroundWorker finished. This is used to update the values for the next level-up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Worker completed.");
            // detects if worker was cancelled manually
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {

            }
            // stop worker
            worker.CancelAsync();
            worker.Dispose();
            // update
            currentXP = 0;
            ShowIncreaseButtons();
            UpdateLevelConstraints();
            UpdateProgressBar();
            // restart worker on new thread
        }

        private void UpdateAttackRate()
        {
            currentAttackRate = (int)(baseAttackRate - convertRatioHR * Math.Log(currentHR));
            AttackRateValue.Content = currentAttackRate;
        }

        private void UpdateLevelConstraints()
        {
            currentLevel += 1;
            minDamageValueForLevel = maxDamageValueForLevel;
            maxDamageValueForLevel = (int)(maxDamageValueForLevel * Math.Exp(currentLevel));
        }

        private void UpdateDamageConstraints()
        {
            currentMinDamage = (int)(minDamage * convertRatioAP * Math.Log(currentAP));
            currentMaxDamage = (int)(maxDamage * convertRatioAP * Math.Log(currentAP));
        }

        private void UpdateProgressBar()
        {
            XPBar.Value = 0;
        }

        private void IncreaseAP(object sender, RoutedEventArgs e)
        {
            currentAP += 1;
            UpdateDamageConstraints();
            HideIncreaseButtons();

            Log.Text = "Attack Power upgraded by 1.\n";
        }

        private void IncreaseCR(object sender, RoutedEventArgs e)
        {
            currentCR += 1;
            HideIncreaseButtons();
            Log.Text = "Critical Strike Rating upgraded by 1.\n";
        }

        private void IncreaseHR(object sender, RoutedEventArgs e)
        {
            currentHR += 1;
            UpdateAttackRate();
            HideIncreaseButtons();
            Log.Text = "Haste Rating upgraded by 1.\n";
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

        private void StartBeatbox(object sender, RoutedEventArgs e)
        {
            StartWorker();

            Log.Text = "Starting to hit stuff...\n";
        }

        private void StopBeatbox(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
            Log.Text = "Enough hitting, stopping now.\n";
        }
    }
}
