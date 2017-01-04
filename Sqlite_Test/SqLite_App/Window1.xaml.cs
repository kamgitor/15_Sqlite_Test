using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SQLite;

namespace SqLite_App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        SQLiteConnection m_dbConnection;

        /*
                private SQLiteDataAdapter m_oDataAdapter = null;             // to zglasza wyjatek
                private DataSet m_oDataSet = null;
                private DataTable m_oDataTable = null;
                */

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CreateNewDatabase();
            ConnectToDatabase();
            CreateTable();
            FillTable();
            // PrintTable();
        }


        void CreateNewDatabase()
        {
            SQLiteConnection.CreateFile("Baza.s3db");
        }

        // Creates a connection with our database file.
        void ConnectToDatabase()
        {
            // m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection = new SQLiteConnection("Data Source=Baza.s3db;Version=3;");
            m_dbConnection.Open();
        }

        void CreateTable()
        {
            // string sql = "create table Spiewnik (name varchar(20), score int)";
            string sql = "create table Spiewnik (Numer int, Numer2 int, Tytul TEXT, Tekst TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

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
