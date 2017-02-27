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
        public void DBConnection() {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=binnenschifffahrt;uid=FA53_osz;password=osz");
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from t_sbf_binnen";

                

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Es ist ein Fehler aufgetreten:" + Environment.NewLine + ex, "An error occurred");                
            }
            
            

            

            
        }        
    }
}
