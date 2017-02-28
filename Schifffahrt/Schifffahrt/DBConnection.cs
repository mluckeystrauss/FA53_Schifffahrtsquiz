using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Schifffahrt
{
    class DBConnection
    {
        public MySqlConnection connection;

        public DBConnection() {
            try
            {
                //this.connection = new MySqlConnection("server=localhost;database=binnenschifffahrt;uid=root;password=");
                //connection.Open();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Es ist ein Fehler aufgetreten:" + Environment.NewLine + ex, "An error occurred");                
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
