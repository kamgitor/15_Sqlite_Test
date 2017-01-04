// Author: Tigran Gasparian
// This sample is part Part One of the 'Getting Started with SQLite in C#' tutorial at http://www.blog.tigrangasparian.com/

using System;
using System.Data.SQLite;

namespace SQLiteSamples
{
    class Program
    {
        // Holds our connection with the database
        SQLiteConnection m_dbConnection;

        static void Main(string[] args)
        {
            Program p = new Program();
        }

        public Program() 
        {
            CreateNewDatabase();
            ConnectToDatabase();
            CreateTable();
            FillTable();
            // PrintTable();
        }

        // Creates an empty database file
        void CreateNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        // Creates a connection with our database file.
        void ConnectToDatabase()
        {
            // m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection = new SQLiteConnection("Data Source=Baza.s3db;Version=3;");
            m_dbConnection.Open();
        }

        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        void CreateTable()
        {
            // string sql = "create table Spiewnik (name varchar(20), score int)";
            string sql = "create table Spiewnik (Numer int, Numer2 int, Tytul TEXT, Tekst TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        void FillTable()
        {
            string sql = "insert into Spiewnik (Numer, Numer2, Tytul, Tekst) values (1, 2, 'Jezusa kocham', 'Jezusa kocham i jestem pewny że, Ja na nim nigdy nie zawiodę się')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Spiewnik (Numer, Numer2, Tytul, Tekst) values (2, 3, 'Przyjaciela mam', 'Przyjaciela mam, co pokrzepia mnie')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Spiewnik (Numer, Numer2, Tytul, Tekst) values (3, 5, 'W Tobie', 'W Tobie wszystko mam w Tobie, Wszystko mam w Tobie, W Tobie Jezu')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        // Writes the highscores to the console sorted on score in descending order.
        void PrintTable()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }

    }
}
