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

// Trzeba dodac do projektu
// http://www.altcontroldelete.pl/artykuly/c-wpf-oraz-sqlite-razem-w-jednym-projekcie/
// Add Reference System.Data.SqLite Core
// Add Existing Item Baza.s3db
//      - zmieniamy properties bazy: Build Action -> Content
//      - zmianiamy Copy to output directory -> Copy Allways

using System.Data;
using System.Data.SQLite;
// using Sqlite_Test;

namespace Sqlite_Test
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

        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            SQLiteConnection oSQLiteConnection = new SQLiteConnection("Data Source=Baza.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Spiewnik";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText, oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            // lstItems.DataContext = m_oDataTable.DefaultView;

        }
    }
}
