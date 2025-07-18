using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace ApplicationThirteen
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string dbPath = "workflow.db";

            // Create the database file if it doesn't exist
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
 @"
CREATE TABLE IF NOT EXISTS Reports (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ProjectName TEXT NOT NULL,
    ReportType TEXT NOT NULL,
    CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Items (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ReportId INTEGER NOT NULL,
    ItemName TEXT NOT NULL,
    InstallationLocation TEXT,
    MountingType TEXT,
    LightingIssue TEXT,
    Orientation TEXT,
    RackDistance TEXT,
    CameraHeight TEXT,
    Remarks TEXT,
    PhotoPath TEXT,
    FOREIGN KEY (ReportId) REFERENCES Reports(Id)
);
";



                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}