using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationThirteen // Make sure this matches your App.xaml namespace
{
    public partial class CreateNewReport : Window
    {
        public CreateNewReport()
        {
            InitializeComponent();
        }

        private void CreateNewReport_Click(object sender, RoutedEventArgs e)
        {
            string address1 = Address1.Text.Trim();
            string address2 = Address2.Text.Trim();
            string postalCode = PostalCode.Text.Trim();
            string projectType = (ProjectType.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(address1) || string.IsNullOrWhiteSpace(postalCode) || projectType == "Select 1")
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string projectName = $"{address1} {postalCode}"; // You can customize the logic here

            try
            {
                using (var conn = new SQLiteConnection("Data Source=workflow.db;Version=3;"))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Reports (ProjectName, ReportType)
                        VALUES (@ProjectName, @ReportType);
                        SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@ProjectName", projectName);
                    cmd.Parameters.AddWithValue("@ReportType", projectType);

                    int newReportId = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show("Report created successfully!", "Success");

                    // Navigate to AddItem and pass ReportId
                    var addItemWindow = new AddItem(newReportId);
                    addItemWindow.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating report: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}



