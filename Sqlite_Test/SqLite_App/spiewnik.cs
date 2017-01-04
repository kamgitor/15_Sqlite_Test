using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SQLite;

namespace SqLite_App
{

	public class Spiewnik
	{
		static SQLiteConnection m_dbConnection;

		// *******************************************************
		static public void CreateDatabase()
		{
			SQLiteConnection.CreateFile("Baza.s3db");

		}   // CreateDatabase


		// *******************************************************
		// Creates a connection with our database file.
		static public void ConnectToDatabase()
		{
			// m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
			m_dbConnection = new SQLiteConnection("Data Source=Baza.s3db;Version=3;");
			m_dbConnection.Open();

		}   // ConnectToDatabase


		// *******************************************************
		static public void CreateTable()
		{
			// string sql = "create table Spiewnik (name varchar(20), score int)";
			string sql = "create table Spiewnik (Numer int, Numer2 int, Tytul TEXT, Tekst TEXT)";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();

		}   // CreateTable


		// *******************************************************
		static public void FillTestTable()
		{
			CreateSong(1, 2, "Jezusa mam", "Jezusa mam i jestem pewny że\r\nJa na nim nigdy nie zawiodę się");
			CreateSong(2, 5, "Przyjaciela mam", "Przyjaciela mam, co pokrzepia mnie");
			CreateSong(3, 6, "W Tobie", "W Tobie wszystko mam w Tobie\r\nWszystko mam w Tobie, W Tobie Jezu");
			CreateSong(4, 7, "Jesteśmy w Nim", "Jesteśmy w Nim, i w Nim\r\njest nasze życie");		

		}   // FillTestTable


		// *******************************************************
		static public void CreateSong(int num, int num2, string name, string content)
		{
			string sql = "insert into Spiewnik (Numer, Numer2, Tytul, Tekst) values (";
			sql += num.ToString();
			sql += ", ";
			sql += num2.ToString();
			sql += ", '";
			sql += name;
			sql += "', '";
			sql += content;
			sql += "')";

			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();

		}   // CreateSong


		// *******************************************************
		static public void GetSong(int pos, out int num, out int num2, out string name, out string content)
		{
			num = 0;
			num2 = 0;
			name = "";
			content = "";

		}   // GetSong


		// *******************************************************
		// Writes the highscores to the console sorted on score in descending order.
		static public void PrintTable()
		{
			string sql = "select * from highscores order by score desc";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read())
				Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
			Console.ReadLine();

		}   // PrintTable


	}   // class Spiewnik

}   // namespace SqLite_App
