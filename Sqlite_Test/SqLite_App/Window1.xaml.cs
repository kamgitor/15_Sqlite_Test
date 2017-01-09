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
		
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Spiewnik.CreateDatabase();
            Spiewnik.ConnectToDatabase();
            Spiewnik.CreateTable();
            Spiewnik.FillTestTable();
            // Spiewnik.PrintTable();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
			Spiewnik.Debug();

        }

		private void button_Click_Num1(object sender, RoutedEventArgs e)
		{
			SongList.Items.Clear();
			if (InNumber.Text != "")
			{
				Spiewnik.ConnectToDatabase();
				// string content = string.Format("%{0}%", );
				List<Song> songs = Spiewnik.GetSongByNumber1(Convert.ToInt32(InNumber.Text));      // "%JESTEŚMY%"
				SongList.Items.Clear();
				foreach (Song song in songs)
				{
					SongList.Items.Add(song.number1.ToString() + " (" + song.number2.ToString() + ")  " + song.name);
					// SongList.Items.Add(song.name + "  " + song.content);
				}
			}
		}

		private void button_Click_Num2(object sender, RoutedEventArgs e)
		{
			SongList.Items.Clear();
			if (InNumber.Text != "")
			{
				Spiewnik.ConnectToDatabase();
				// string content = string.Format("%{0}%", InNumber.Text);
				List<Song> songs = Spiewnik.GetSongByNumber2(Convert.ToInt32(InNumber.Text));      // "%JESTEŚMY%"

				foreach (Song song in songs)
				{
					SongList.Items.Add(song.number1.ToString() + " (" + song.number2.ToString() + ")  " + song.name);
					// SongList.Items.Add(song.name + "  " + song.content);
				}
			}
		}

		private void button_Click_Name(object sender, RoutedEventArgs e)
		{
			SongList.Items.Clear();
			if (InName.Text != "")
			{
				Spiewnik.ConnectToDatabase();
				string content = string.Format("%{0}%", InName.Text);
				List<Song> songs = Spiewnik.GetSongByNameMask(content);      // "%JESTEŚMY%"

				foreach (Song song in songs)
				{
					SongList.Items.Add(song.number1.ToString() + " (" + song.number2.ToString() + ")  " + song.name);
					// SongList.Items.Add(song.name + "  " + song.content);
				}
			}
		}

		private void button_Click_Content(object sender, RoutedEventArgs e)
		{
			SongList.Items.Clear();
			if (InContent.Text != "")
			{
				Spiewnik.ConnectToDatabase();
				string content = string.Format("%{0}%", InContent.Text);
				List<Song> songs = Spiewnik.GetSongByContentMask(content);      // "%JESTEŚMY%"

				foreach (Song song in songs)
				{

					song.content = Spiewnik.SimplifyContent(song.content, InContent.Text);
					SongList.Items.Add(song.number1.ToString() + " (" + song.number2.ToString() + ")  " + song.content);
				}
			}
		}
	}
}
