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
using System.Windows.Shapes;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für Configuration.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            var applicationTitleValue = applicationTitleConfig.Text;
            var percentageToPassValue = percentageToPassConfig.Text;
            var savingErrorText = "";
            var savingError = false;


            if (applicationTitleValue != "")
            {
                Properties.Settings.Default.ApplicationTitle = applicationTitleConfig.Text;
            } else
            {
                savingErrorText += "Titel:\n\tBitte geben Sie einen Titel für das Programm ein.";
                savingError = true;
            }

            if (percentageToPassValue != "")
            {
                var value = Convert.ToInt32(percentageToPassValue);
                if (value > 0 && value <= 100)
                {
                    Properties.Settings.Default.PercentageToPass = value;
                }
                else
                {
                    savingErrorText += "\nBenötigte Prozente:\n\tBitte geben Sie eine Zahl zwischen 0 und 100 ein.";
                    savingError = true;
                }
            }

            if (!savingError)
            {
                Properties.Settings.Default.Save();
                mainWindow.Show();
                mainWindow.applicationTitle.Content = applicationTitleValue;
                this.Close();
            } else
            {
                MessageBox.Show(savingErrorText, "Fehler beim abspeichern");
            }
        }
    }
}
