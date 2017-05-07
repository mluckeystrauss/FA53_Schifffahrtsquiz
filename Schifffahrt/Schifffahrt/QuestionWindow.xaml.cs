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
using System.IO;
using System.Windows.Navigation;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private Questionnaire questionnaire { get; set; }

        private List<RadioButton> radioBtns ;


        
        public QuestionWindow()
        {
            InitializeComponent();
            this.Title = App.Current.Properties["programHeader"].ToString();
            lblBogen.Content = "Prüfungsbogen Nummer: " + Controller.sharedData.FragebogenId;
            this.questionnaire = new Questionnaire(Controller.sharedData.Questions, Controller.sharedData.Answers);
            this.setFormFields();
            radioBtns = new List<RadioButton> { rbQuest1 , rbQuest2, rbQuest3 , rbQuest4 };
            btnPrevious.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) > 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = this.questionnaire.Count;
            
            
        }
       

       


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (questionnaire.Done && this.questionnaire.SelectedIndex == this.questionnaire.Questions.Count - 1)
            {
                Evaluation eval = new Evaluation();
                eval.Show();
                this.Close();
            }

            this.questionnaire.Next();
            if (this.questionnaire.Current.Is_Answered)
            {
                var currentAnswerNumber = this.questionnaire.Current.Given_Answer;
                this.radioBtns[currentAnswerNumber - 1].IsChecked = true;
            }
            else
            {
                this.radioBtns.ForEach(btn => btn.IsChecked = false);
            }
            btnPrevious.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) > 0;
            btnNext.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) < this.questionnaire.Questions.Count - 1;  
            this.setFormFields();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            btnNext.Content = "zur nächsten Frage";
            this.questionnaire.Previous();
            if (this.questionnaire.Current.Is_Answered)
            {
                var currentAnswerNumber = this.questionnaire.Current.Given_Answer;
                this.radioBtns[currentAnswerNumber - 1].IsChecked = true;
            }
            else
            {
                this.radioBtns.ForEach(btn => btn.IsChecked = false);
            }
            btnPrevious.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) > 0;
            btnNext.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) < this.questionnaire.Questions.Count;
            this.setFormFields();
        }

        void setFormFields()
        {
            var question = Regex.Replace(this.questionnaire.Current.Text, "(\\{.*\\})", string.Empty);
            var picture = Regex.Match(this.questionnaire.Current.Text, "(\\{.*\\})",RegexOptions.IgnorePatternWhitespace);
            tbFrage.Text = (this.questionnaire.Questions.IndexOf(this.questionnaire.Current) + 1) + ". Frage: " + question;
            var answers = this.questionnaire.Current.Answers;
            rbQuest1.Content = answers[0].Text;
            rbQuest2.Content = answers[1].Text;
            rbQuest3.Content = answers[2].Text;
            rbQuest4.Content = answers[3].Text;
            if ( !picture.Success )
            {
                imgQuestion.Source = null;
            } else
            {
                
                string appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string resourcesFolderPath = System.IO.Path.Combine(
                Directory.GetParent(appFolderPath).Parent.FullName, "Resources");
                imgQuestion.Source = new BitmapImage(new Uri(String.Format("file:///{0}/" + Regex.Match(picture.Value, "[1-9]*.gif").Value, resourcesFolderPath)));
            }
           
        }

        private void rbQuest1_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 1;
            if (this.questionnaire.Done && this.questionnaire.SelectedIndex == this.questionnaire.Questions.Count - 1)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
            }
            progressBar.Value = this.questionnaire.Answered();
        }

        private void rbQuest2_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 2;
            if (this.questionnaire.Done && this.questionnaire.SelectedIndex == this.questionnaire.Questions.Count - 1)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
            }
            progressBar.Value = this.questionnaire.Answered();
        }

        private void rbQuest3_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 3;
            if (this.questionnaire.Done && this.questionnaire.SelectedIndex == this.questionnaire.Questions.Count - 1)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
            }
            progressBar.Value = this.questionnaire.Answered();
        }

        private void rbQuest4_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 4;
            if (this.questionnaire.Done && this.questionnaire.SelectedIndex == this.questionnaire.Questions.Count - 1)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
            }
            progressBar.Value = this.questionnaire.Answered();
        }
    }
}
