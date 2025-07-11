using System.Windows;
using System.Windows.Controls;

namespace DigitalWorkflowApp
{
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent(); // this links the XAML and C#
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...");
            this.Close();
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            string project = (ProjectNameComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string reportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(project) || string.IsNullOrWhiteSpace(reportType))
            {
                MessageBox.Show("Please select both Project Name and Report Type.");
                return;
            }

            MessageBox.Show($"Creating new report for {project} - {reportType}");
        }

        private void EditViewReport_Click(object sender, RoutedEventArgs e)
        {
            string project = (ProjectNameComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string reportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(project) || string.IsNullOrWhiteSpace(reportType))
            {
                MessageBox.Show("Please select both Project Name and Report Type.");
                return;
            }

            MessageBox.Show($"Opening {reportType} for {project}");
        }
    }
}
