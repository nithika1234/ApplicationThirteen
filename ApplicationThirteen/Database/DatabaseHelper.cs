using System;
using System.Data.SQLite;
using System.IO;

namespace ApplicationThirteen.Database
{
    public static class DatabaseHelper
    {
        public static void Initialize(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Reports (
                            ReportId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProjectName TEXT,
                            ReportType TEXT,
                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        CREATE TABLE IF NOT EXISTS Items (
                            ItemId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ReportId INTEGER,
                            ItemName TEXT,
                            Remarks TEXT,
                            PhotoPath TEXT,
                            FOREIGN KEY (ReportId) REFERENCES Reports(ReportId)
                        );
                    ";

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


