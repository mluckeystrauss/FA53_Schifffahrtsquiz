using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBConnection db = new DBConnection();
            App.Current.Properties["db"] = db;
            App.initializeQuestionnaire();
        }
        
         private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Evaluation windowEv = new Evaluation();
            windowEv.tbWrongQuestion.Text += "More Text hashahhahashahhahashahhahashhahhahashaashahhahahashahhahashahhahashahhahashahhahashahhahashahhahashahhahashahhahashahha";
            windowEv.tbWrongAnswer.Text += "";
            windowEv.Show();
        }


        private void Button_Configuration_Click(object sender, RoutedEventArgs e)
        {
            var configurationWindow = new ConfigurationWindow();
            configurationWindow.Show();
            this.Close();
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comming soon!");
        }
    }
}
