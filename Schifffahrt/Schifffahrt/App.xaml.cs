using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static void initializeQuestionnaire()
        {
            DBConnection db = (DBConnection)App.Current.Properties["db"];
            MySqlCommand cmd = db.connection.CreateCommand();

            cmd.CommandText = "select * from t_sbf_binnen;";

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var o = reader["Frage"] as string;
                    MessageBox.Show(o);
                }
            }
        }
    }
}
