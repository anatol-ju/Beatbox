using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beatbox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MilestoneDialog : Window
    {
        public MilestoneDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
