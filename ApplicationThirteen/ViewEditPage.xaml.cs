using DigitalWorkflowApp;
using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationThirteen
{
    public partial class ViewEditPage : Window
    {
        public ViewEditPage()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            ReportListBox.Items.Clear();
            using (var conn = new SQLiteConnection("Data Source=workflow.db;Version=3;"))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, ProjectName FROM Reports ORDER BY Id DESC";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        ReportListBox.Items.Add($"{id}: {name}");
                    }
                }
            }
        }

        private int? GetSelectedReportId()
        {
            if (ReportListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a report first.", "Selection Required");
                return null;
            }

            string selected = ReportListBox.SelectedItem.ToString();
            string[] parts = selected.Split(':');
            if (parts.Length >= 1 && int.TryParse(parts[0], out int reportId))
            {
                return reportId;
            }

            return null;
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            int? reportId = GetSelectedReportId();
            if (reportId.HasValue)
            {
                // Open a view-only window (you can later customize this)
                MessageBox.Show($"Viewing Report ID: {reportId.Value}");
                new ViewReportPage(reportId.Value).Show();
                this.Close();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int? reportId = GetSelectedReportId();
            if (reportId.HasValue)
            {
                // Open the AddItem/EditItems page to edit the report
                AddItem editPage = new AddItem(reportId.Value);
                editPage.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
            this.Close();
        }

       
    }
}
