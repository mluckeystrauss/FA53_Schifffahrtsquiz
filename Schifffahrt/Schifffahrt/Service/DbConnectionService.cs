using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;
using Schifffahrt.Model;

namespace Schifffahrt.Service
{
    class DbConnectionService
    {
        public MySqlConnection connection;

        public DbConnectionService()
        {
            try
            {
                this.connection = new MySqlConnection("server=localhost;database=binnenschifffahrt;uid=root;password=");
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Es ist ein Fehler aufgetreten:" + Environment.NewLine + ex, "An error occurred");
            }
        }

        public DataTable executeCommand(string commandstring)
        {
            this.connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(commandstring, this.connection);

            DataSet ds = new DataSet();

            da.Fill(ds);

            this.Close();
            return ds.Tables[0];
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
