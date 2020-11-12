using System.Collections.ObjectModel;
using System.Windows;

namespace Beatbox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MilestoneDialog : Window
    {
        public ObservableCollection<Milestone> MilestonesList { private get; set; }

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
