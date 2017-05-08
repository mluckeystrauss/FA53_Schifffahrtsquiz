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

        private List<RadioButton> radioBtns;

        public QuestionWindow()
        {
            InitializeComponent();

            this.Title = App.Current.Properties["applicationTitle"].ToString();
            sheetTitle.Content = "Prüfungsbogen Nummer: " + Controller.sharedData.FragebogenId;
            this.questionnaire = Controller.sharedData.Questionnaire;
            this.setFormFields();

            radioBtns = new List<RadioButton> { rbQuest1, rbQuest2, rbQuest3, rbQuest4 };
            btnPrevious.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) > 0;

            progressBar.Minimum = 0;
            progressBar.Maximum = this.questionnaire.Count;

            // bind data for progress buttons
            List<ProgressButtonItem> buttonItems = new List<ProgressButtonItem>();
            for (int i = 0; i < this.questionnaire.Count; i++)
            {
                var progressButtonData = new ProgressButtonItem();

                buttonItems.Add(new ProgressButtonItem() { Content = Convert.ToString(i + 1) });
                itemControlProgressButtons.ItemsSource = buttonItems;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    this.previousQuestion();
                    break;
                case Key.Right:
                    this.nextQuestion();
                    break;
            }
        }

        private void previousQuestion()
        {
            btnNext.Content = "Zur nächsten Frage";
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

        private void nextQuestion()
        {
            if (this.questionnaire.Done && (string)btnNext.Content == "Zur Auswertung ...")
            {
                Evaluation eval = new Evaluation();
                //Questionnaire speichern
                Controller.sharedData.Questionnaire = this.questionnaire;
                eval.Show();
                this.Close();
            }
            if (this.questionnaire.Done && this.questionnaire.Answered() == this.questionnaire.Questions.Count)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
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
            btnNext.IsEnabled = this.questionnaire.Questions.IndexOf(this.questionnaire.Current) < this.questionnaire.Questions.Count - 1 || this.questionnaire.Done;
            this.setFormFields();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.previousQuestion();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.nextQuestion();
        }

        void setFormFields()
        {
            var question = Regex.Replace(this.questionnaire.Current.Text, "(\\{.*\\})", string.Empty);
            var picture = Regex.Match(this.questionnaire.Current.Text, "(\\{.*\\})", RegexOptions.IgnorePatternWhitespace);
            tbFrage.Text = (this.questionnaire.Questions.IndexOf(this.questionnaire.Current) + 1) + ". Frage: " + question;
            var answers = this.questionnaire.Current.Answers;
            rbQuest1.Content = answers[0].Text;
            rbQuest2.Content = answers[1].Text;
            rbQuest3.Content = answers[2].Text;
            rbQuest4.Content = answers[3].Text;

            if (!picture.Success)
            {
                imgQuestion.Source = null;
            }
            else
            {

                string appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string resourcesFolderPath = System.IO.Path.Combine(
                Directory.GetParent(appFolderPath).Parent.FullName, "Resources");
                try
                {
                    imgQuestion.Source = new BitmapImage(new Uri(String.Format("file:///{0}/" + Regex.Match(picture.Value, "[1-9]*.gif").Value, resourcesFolderPath)));

                }
                catch (System.IO.FileNotFoundException e)
                {

                    System.Diagnostics.Debug.Print(e.Message);
                }
            }

        }

        private void rbQuest1_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 1;
            this.rbQuest_Checked(this.questionnaire.Done, this.questionnaire.Answered(), this.questionnaire.Questions.Count);

        }

        private void rbQuest2_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 2;
            this.rbQuest_Checked(this.questionnaire.Done, this.questionnaire.Answered(), this.questionnaire.Questions.Count);
        }

        private void rbQuest3_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 3;
            this.rbQuest_Checked(this.questionnaire.Done, this.questionnaire.Answered(), this.questionnaire.Questions.Count);
        }

        private void rbQuest4_Checked(object sender, RoutedEventArgs e)
        {
            this.questionnaire.Current.Given_Answer = 4;
            this.rbQuest_Checked(this.questionnaire.Done, this.questionnaire.Answered(), this.questionnaire.Questions.Count);
        }

        private void rbQuest_Checked(bool done, int answered, int questionsCount)
        {
            if (done && answered == questionsCount)
            {
                btnNext.Content = "Zur Auswertung ...";
                btnNext.IsEnabled = true;
            }
            progressBar.Value = answered;
        }

        private void Progress_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var buttonContent = Convert.ToInt16(button.Content);
            var newIndex = buttonContent - 1;

            this.questionnaire.SelectedIndex = newIndex;
            this.setFormFields();

            if (this.questionnaire.Current.Is_Answered)
            {
                var currentAnswerNumber = this.questionnaire.Current.Given_Answer;
                this.radioBtns[currentAnswerNumber - 1].IsChecked = true;
            }
            else
            {
                this.radioBtns.ForEach(btn => btn.IsChecked = false);
            }
        }
    }

    public class ProgressButtonItem
    {
        public string Content { get; set; }
    }
}
