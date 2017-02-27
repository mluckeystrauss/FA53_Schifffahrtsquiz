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

            InitializeQuestionnaire();
        }
        
         private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Evaluation windowEv = new Evaluation();
            windowEv.Show();
        }


        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new HomeWindow();
            homeWindow.Show();
        }


        private void Button_Configuration_Click(object sender, RoutedEventArgs e)
        {
            var ConfigurationWindow = new ConfigurationWindow();
            ConfigurationWindow.Show();
        }

        public static void InitializeQuestionnaire()
        {
            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer("Madrid", false));
            answers.Add(new Answer("Rom", false));
            answers.Add(new Answer("Berlin", true));
            answers.Add(new Answer("Warschau", false));

            List<Question> questions = new List<Question>();
            questions.Add(new Question("Wie heißt die Hauptstadt Deutschlands?", answers));

            answers.Clear();
            answers.Add(new Answer("Madrid", false));
            answers.Add(new Answer("Rom", true));
            answers.Add(new Answer("Berlin", false));
            answers.Add(new Answer("Warschau", false));

            questions.Add(new Question("Wie heißt die Hauptstadt Italiens?", answers));
            Questionnaire q = new Questionnaire(questions);

            App.Current.Properties["Questionnaire"] = q;
        }
    }
}
