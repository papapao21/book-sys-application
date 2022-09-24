using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public static class CreateDB
    {
        private static string _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\Database\\BookSystem.sqlite;version=3";

        public static void CreateBook()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS Book (BookID INTEGER PRIMARY KEY, Title TEXT, Author TEXT, AverageRating TEXT, CurrentBorrower TEXT)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public static void DropBook()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            m_dbConnection.Open();

            string sql = "DROP TABLE Book";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public static void DropReview()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            m_dbConnection.Open();

            string sql = "DROP TABLE Review";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public static void CreateReview()
        {
            
            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS Review (ID INTEGER PRIMARY KEY, BookID INTEGER, Review TEXT, Rating INT, ReviewBy TEXT, ReviewDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        public static void CreateBorrower()
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection(_connectionString);
            m_dbConnection.Open();
            
            string sql = "CREATE TABLE IF NOT EXISTS Borrower (ID INTEGER PRIMARY KEY, BookID INTEGER, Borrower TEXT, BorrowDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
    }
}
