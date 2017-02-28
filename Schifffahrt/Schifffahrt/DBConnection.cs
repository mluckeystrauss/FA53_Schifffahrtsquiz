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
using System.Data;
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
                this.connection = new MySqlConnection("server=localhost;database=binnenschifffahrt;uid=root;password=");
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Es ist ein Fehler aufgetreten:" + Environment.NewLine + ex, "An error occurred");                
            }
        }

        public DataTable executeCommand(string commandstring, string tableName)
        {
            this.connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(commandstring, this.connection);

            DataSet ds = new DataSet();

            da.Fill(ds, tableName);

            this.Close();
            return ds.Tables[tableName]; ;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
