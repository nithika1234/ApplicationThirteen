using ApplicationThirteen;
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

        private void CreateNewReport_Click(object sender, RoutedEventArgs e)
        {
            string project = (ProjectNameComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string reportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(project) || string.IsNullOrWhiteSpace(reportType))
            {
                MessageBox.Show("Please select both Project Name and Report Type.");
                return;
            }

            // Open the CreateNewReport window
            var createReportWindow = new CreateNewReport();
            createReportWindow.Show();
            this.Close();
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

            // Optional: show confirmation
            MessageBox.Show($"Opening {reportType} for {project}");

            // ✅ Navigate to the ViewEditPage
            ViewEditPage viewEditPage = new ViewEditPage();
            viewEditPage.Show();

            // Optional: Close current Home page
            this.Close();
        }
    }
}
