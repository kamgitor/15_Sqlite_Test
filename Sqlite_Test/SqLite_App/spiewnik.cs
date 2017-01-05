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

		static private int numer;
		static private int numer2;
		static private string nazwa;
		static private string tekst;

		// UWAGA
		// W zapytaniu kazda spacje zamieniac na % i bedzie git - automatycznie pomijanie przecinkow i enterow
		// Pytanie jeszcze jak zrobic pomijanie polskich liter
		// Polskie znaki w wyszukiwaniu chyba trzebaby zamienic na _ bo, do przy polskich literach nie olewa wielkosc liter



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
			string sql = "CREATE TABLE Spiewnik (Numer int, Numer2 int, Tytul TEXT, Tekst TEXT)";
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
        static public void Debug()
        {
			int num;
			int num2;
			string name;
			string content;
			// CreateSong(1, 2, "Jezusa mam", "Jezusa mam i jestem pewny że\r\nJa na nim nigdy nie zawiodę się");

			ConnectToDatabase();
			// GetSongByNumer1(1, out num, out num2, out name, out content);
			//			GetSongByNameMask("%Jesteśmy%", out num, out num2, out name, out content);


			GetSongByTekstMask("%JESTEŚMY%");	// , out num, out num2, out name, out content);

/*
			try
			{
				GetSongByNameMask("%Jestesmy%", out num, out num2, out name, out content);
			}
			catch { }

			GetSongByNameMask("%Jeste_my%", out num, out num2, out name, out content);

			GetSongByNameMask("%mam%", out num, out num2, out name, out content);

			GetSongByTekstMask("%jezusa mam%", out num, out num2, out name, out content);
			GetSongByTekstMask("%jeste_my%", out num, out num2, out name, out content);
			GetSongByTekstMask("%jestesmy%", out num, out num2, out name, out content);
			GetSongByTekstMask("%nim%", out num, out num2, out name, out content);
			GetSongByTekstMask("%nim i%", out num, out num2, out name, out content);
			GetSongByTekstMask("%pewny ze ja%", out num, out num2, out name, out content);
			GetSongByTekstMask("%mam co%", out num, out num2, out name, out content);
*/



		}   // Debug


		// *******************************************************
		static public void CreateSong(int num, int num2, string name, string content)
		{
			string sql = string.Format("INSERT INTO Spiewnik (Numer, Numer2, Tytul, Tekst) VALUES ({0}, {1}, '{2}', '{3}')", num, num2, name, content);
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();

		}   // CreateSong


		// *******************************************************
		// Musi byc polaczenie z baza
		static public void GetSongByNumer1(int pos)		// , out int num, out int num2, out string name, out string content)
		{
			string sql = string.Format("SELECT * FROM Spiewnik WHERE Numer={0}", pos);
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			reader.Read();

			numer = Convert.ToInt32(reader["Numer"]);
			numer2 = Convert.ToInt32(reader["Numer2"]);

			nazwa = reader["Tytul"].ToString();
			tekst = reader["Tekst"].ToString();

		}   // GetSongByNumer1


		// *******************************************************
		// Musi byc polaczenie z baza
		static public void GetSongByNumer2(int pos)		// , out int num, out int num2, out string name, out string content)
		{
			string sql = string.Format("SELECT * FROM Spiewnik WHERE Numer2={0}", pos);
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			reader.Read();

			numer = Convert.ToInt32(reader["Numer"]);
			numer2 = Convert.ToInt32(reader["Numer2"]);

			nazwa = reader["Tytul"].ToString();
			tekst = reader["Tekst"].ToString();

		}   // GetSongByNumer2


		// *******************************************************
		// w masce % oznacza dowolny ciag znakow
		// w masce _ oznacza dowolny znak
		static public bool GetSongByNameMask(string mask)		// , out int num, out int num2, out string name, out string content)
		{
			bool exist;
			// SELECT * FROM Spiewnik WHERE Tytul LIKE '%Tobie%'		<- nie uwzglednia wielkosci liter
			// SELECT * FROM Spiewnik WHERE Tytul GLOB '*Tobie*'		<- uwzglednia wielkosc liter

			string sql = string.Format("SELECT * FROM Spiewnik WHERE Tytul LIKE '{0}'", mask);
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();

			exist = reader.Read();

			if (exist)
			{
				// narazie biore tylko pierwszego z listy
				numer = Convert.ToInt32(reader["Numer"]);
				numer2 = Convert.ToInt32(reader["Numer2"]);

				nazwa = reader["Tytul"].ToString();
				tekst = reader["Tekst"].ToString();
			}

			return exist;

		}   // GetSongByNameMask


		// *******************************************************
		// w masce % oznacza dowolny ciag znakow
		// w masce _ oznacza dowolny znak
		static public bool GetSongByTekstMask(string mask)		// , out int num, out int num2, out string name, out string content)
		{
			bool exist;

			// SELECT * FROM Spiewnik WHERE Tytul LIKE '%Tobie%'		<- nie uwzglednia wielkosci liter
			// SELECT * FROM Spiewnik WHERE Tytul GLOB '*Tobie*'		<- uwzglednia wielkosc liter

			string sql = string.Format("SELECT * FROM Spiewnik WHERE Tekst LIKE '{0}'", mask);
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();

			exist = reader.Read();

			if (exist)
			{
				// narazie biore tylko pierwszego z listy
				numer = Convert.ToInt32(reader["Numer"]);
				numer2 = Convert.ToInt32(reader["Numer2"]);

				nazwa = reader["Tytul"].ToString();
				tekst = reader["Tekst"].ToString();
			}

			return exist;

		}   // GetSongByTekstMask


		// *******************************************************
		// Writes the highscores to the console sorted on score in descending order.
		static public void PrintTable()
		{
			string sql = "SELECT * FROM highscores order by score desc";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read())
				Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
			Console.ReadLine();

		}   // PrintTable


	}   // class Spiewnik

}   // namespace SqLite_App
