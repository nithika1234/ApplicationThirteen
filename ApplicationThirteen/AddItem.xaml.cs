using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationThirteen
{
    public partial class AddItem : Window
    {
        private int _reportId;

        public AddItem(int reportId)
        {
            InitializeComponent();
            _reportId = reportId;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string itemName = ItemName.Text.Trim();
            string installLocation = ((ComboBoxItem)InstallLocation.SelectedItem)?.Content.ToString() ?? "";
            string mountType = ((ComboBoxItem)MountType.SelectedItem)?.Content.ToString() ?? "";
            string lightIssue = ((ComboBoxItem)LightIssue.SelectedItem)?.Content.ToString() ?? "";
            string orientation = ((ComboBoxItem)Orientation.SelectedItem)?.Content.ToString() ?? "";
            string rackDistance = RackDistance.Text.Trim();
            string cameraHeight = CameraHeight.Text.Trim();
            string remarks = InsertRemarks.Text.Trim();

            try
            {
                using (var conn = new SQLiteConnection("Data Source=workflow.db;Version=3;"))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();

                    cmd.CommandText = @"
                        INSERT INTO Items (
                            ReportId,
                            ItemName,
                            InstallationLocation,
                            MountingType,
                            LightingIssue,
                            Orientation,
                            RackDistance,
                            CameraHeight,
                            Remarks,
                            PhotoPath
                        )
                        VALUES (
                            @ReportId,
                            @ItemName,
                            @InstallLocation,
                            @MountType,
                            @LightIssue,
                            @Orientation,
                            @RackDistance,
                            @CameraHeight,
                            @Remarks,
                            @PhotoPath
                        );";

                    cmd.Parameters.AddWithValue("@ReportId", _reportId);
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    cmd.Parameters.AddWithValue("@InstallLocation", installLocation);
                    cmd.Parameters.AddWithValue("@MountType", mountType);
                    cmd.Parameters.AddWithValue("@LightIssue", lightIssue);
                    cmd.Parameters.AddWithValue("@Orientation", orientation);
                    cmd.Parameters.AddWithValue("@RackDistance", rackDistance);
                    cmd.Parameters.AddWithValue("@CameraHeight", cameraHeight);
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.Parameters.AddWithValue("@PhotoPath", ""); // Update later if image upload is added

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Item added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting item:\n" + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
