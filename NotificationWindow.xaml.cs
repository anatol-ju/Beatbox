using System;
using System.Windows;

namespace Beatbox
{
    public partial class NotificationWindow : Window
    {
        public new string Title
        {
            get => (string)title.Content;
            set
            {
                title.Content = value;
            }
        }

        public new string Content
        {
            get => (string)content.Content;
            set
            {
                content.Content = value;
            }
        }

        public NotificationWindow() : base()
        {
            InitializeComponent();
            this.Closed += this.NotificationWindowClosed;
        }
        /*
        private void ShowNotificationExecute()
        {
            App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
                () =>
                {
                    var notify = new NotificationWindow();
                    notify.Show();
                }));
        }*/

        public new void Show()
        {
            if ((string)content.Content == "")
            {
                separator.IsEnabled = false;
            }

            this.Topmost = true;
            base.Show();

            this.Owner = System.Windows.Application.Current.MainWindow;
            this.Closed += this.NotificationWindowClosed;
            //var workingArea = System.Windows.SystemParameters.WorkArea;
            
            //this.Left = workingArea
            //this.Left = workingArea.Right - this.ActualWidth;
            //double top = workingArea.Bottom - this.ActualHeight;
            this.Left = Owner.Left + Owner.ActualWidth - this.ActualWidth;
            double top = Owner.Top + Owner.ActualHeight - this.ActualHeight;

            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals("NotificationWindow") && window != this)
                {
                    window.Topmost = true;
                    top = window.Top - window.ActualHeight;
                }
            }

            this.Top = top;
        }
        private void MouseUp_Event(object sender,
            System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            if (!this.IsMouseOver)
            {
                this.Close();
            }
        }
        private void NotificationWindowClosed(object sender, EventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals("NotificationWindow") && window != this)
                {
                    // Adjust any windows that were above this one to drop down
                    if (window.Top < this.Top)
                    {
                        window.Top = window.Top + this.ActualHeight;
                    }
                }
            }
        }
    }
}