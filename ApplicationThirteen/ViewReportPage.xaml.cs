using DigitalWorkflowApp;
using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationThirteen
{
    public partial class ViewReportPage : Window
    {
        private int _reportId;

        public ViewReportPage(int reportId)
        {
            InitializeComponent();
            _reportId = reportId;
            LoadReportDetails();
        }

        private void LoadReportDetails()
        {
            using (var conn = new SQLiteConnection("Data Source=workflow.db;Version=3;"))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT ItemName, InstallationLocation, MountingType, LightingIssue, Orientation,
                           RackDistance, CameraHeight, Remarks
                    FROM Items
                    WHERE ReportId = @ReportId
                    LIMIT 1";

                cmd.Parameters.AddWithValue("@ReportId", _reportId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ItemNameText.Text = reader["ItemName"].ToString();
                        InstallLocationText.Text = reader["InstallationLocation"].ToString();
                        MountTypeText.Text = reader["MountingType"].ToString();
                        LightIssueText.Text = reader["LightingIssue"].ToString();
                        OrientationText.Text = reader["Orientation"].ToString();
                        RackDistanceText.Text = reader["RackDistance"].ToString();
                        CameraHeightText.Text = reader["CameraHeight"].ToString();
                        RemarksText.Text = reader["Remarks"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No item found for this report.");
                    }
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to AddItem (reuse AddItem page for editing too)
            AddItem editWindow = new AddItem(_reportId);
            editWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this report and its items?", "Confirm Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var conn = new SQLiteConnection("Data Source=workflow.db;Version=3;"))
                {
                    conn.Open();

                    // Delete from Items
                    var cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "DELETE FROM Items WHERE ReportId = @ReportId";
                    cmd1.Parameters.AddWithValue("@ReportId", _reportId);
                    cmd1.ExecuteNonQuery();

                    // Delete from Reports
                    var cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "DELETE FROM Reports WHERE Id = @ReportId";
                    cmd2.Parameters.AddWithValue("@ReportId", _reportId);
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Report deleted.");
                HomePage home = new HomePage();
                home.Show();
                Window.GetWindow(this)?.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ViewEditPage backPage = new ViewEditPage();
            backPage.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
