using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für Evaluation.xaml
    /// </summary>
    public partial class Evaluation : Window
    {
        private Questionnaire questionnaire;
        private List<Question> wrongQuestions;
        public Evaluation()
        {
            InitializeComponent();
            this.questionnaire = Controller.sharedData.Questionnaire;
            this.wrongQuestions = new List<Question>();
            tbResultEvaluation.Text = $"\tSie haben {this.questionnaire.Right_Answers()} von {this.questionnaire.Count} Fragen richtig beantwortet.";

            if (questionnaire.Passed)
            {
                tbResultMsg.Text = "Herzlichen Glückwunsch, Sie haben bestanden!";
                Properties.Settings.Default.CourseHistory += ($"\n{Controller.sharedData.Questionnaire.Title} (Fragebogen {Controller.sharedData.FragebogenId}) - bestanden");
            }
            else
            {
                tbResultMsg.Text = "Satz mit x das war wohl nix";
                Properties.Settings.Default.CourseHistory += ($"\n{Controller.sharedData.Questionnaire.Title} (Fragebogen {Controller.sharedData.FragebogenId}) - nicht bestanden");
            }
            Properties.Settings.Default.Save();

            foreach (Question quest in this.questionnaire.Questions)
            {
                if (!quest.Is_Answered_Right)
                {
                    this.wrongQuestions.Add(quest);
                }

            }
            this.fillListbox();
        }

        private void fillListbox()
        {
            for (int i = 0; i < this.wrongQuestions.Count; i++)
            {
                tbWrongQuestion = new TextBlock();
                tbWrongAnswer = new TextBlock();
                tbRightAnswer = new TextBlock();
                lbWrongAnswers.Items.Add(new Separator());
                var questionWithoutBrackets = Regex.Replace(this.wrongQuestions[i].Text, "(\\{.*\\})", string.Empty);
                tbWrongQuestion.Text = $"{this.questionnaire.Questions.IndexOf(this.wrongQuestions[i]) + 1}. Frage :  {questionWithoutBrackets}";
                tbWrongAnswer.Text = $"FALSCH : {this.wrongQuestions[i].Answers[this.wrongQuestions[i].Given_Answer - 1].Text}";
                tbRightAnswer.Text = $"RICHTIG: {this.wrongQuestions[i].Right_Answer_Text}";
                tbWrongQuestion.HorizontalAlignment = HorizontalAlignment.Left;
                tbWrongAnswer.HorizontalAlignment = HorizontalAlignment.Left;
                tbRightAnswer.HorizontalAlignment = HorizontalAlignment.Left;
                lbWrongAnswers.Items.Add(tbWrongQuestion);
                lbWrongAnswers.Items.Add(tbWrongAnswer);
                lbWrongAnswers.Items.Add(tbRightAnswer);
              

            }
        }
        

        private void lblWrongQuestion_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
