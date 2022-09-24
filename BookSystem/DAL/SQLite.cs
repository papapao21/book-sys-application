using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace BookSystem.DAL
{

    public static class SQLite
    {
        private static string _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\Database\\BookSystem.sqlite;version=3";

        public static int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(query, con))
                {
                    foreach (var pair in args)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }

                return numberOfRowsAffected;
            }
        }

        public static DataTable ExecuteRead(string query, Dictionary<string, object> args = null)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    if (args != null)
                        foreach (KeyValuePair<string, object> entry in args)
                            cmd.Parameters.AddWithValue(entry.Key, entry.Value);

                    var da = new SQLiteDataAdapter(cmd);

                    var dt = new DataTable();
                    da.Fill(dt);

                    da.Dispose();
                    return dt;
                }
            }
        }
    }
}
