using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Schifffahrt.Model;
using Schifffahrt.Controller;
using Schifffahrt.Service;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SharedData data;

        void initController()
        {
            SharedDataController.sharedData = new SharedData();
        }
        public MainWindow()
        {
            InitializeComponent();
            initController();
            this.data = SharedDataController.sharedData;
            DbConnectionService db = new DbConnectionService();
            App.Current.Properties["applicationTitle"] =  this.applicationTitle.Content;
            App.Current.Properties["db"] = db;
            //App.initializeQuestions(1);

            // get application title from application settings
            applicationTitle.Content = Schifffahrt.Properties.Settings.Default.ApplicationTitle;
            courseHistory.Text = Schifffahrt.Properties.Settings.Default.CourseHistory;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Configuration_Click(object sender, RoutedEventArgs e)
        {
            var configurationWindow = new ConfigurationWindow();
            configurationWindow.Show();
            this.Close();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
           var item = (ListBoxItem)cboFragebogen.SelectedItem;
            if (item.Content.ToString() == "Funker")
            {
                App.initializeQuestionsRadioOperator();
                SharedDataController.sharedData.FragebogenId = 1;
                SharedDataController.sharedData.Questionnaire = new Questionnaire(this.data.Questions, Schifffahrt.Properties.Settings.Default.PercentageToPass, this.data.Answers, "Funker");

                QuestionWindow windowQuest = new QuestionWindow();
                windowQuest.Show();
                this.Close();

            } else if (cboFragebogen.SelectedIndex > 0)
            {
                App.initializeQuestions(this.data.FragebogenId);
                SharedDataController.sharedData.Questionnaire = new Questionnaire(this.data.Questions, Schifffahrt.Properties.Settings.Default.PercentageToPass, this.data.Answers, "Sportbootführerschein Binnen");
                QuestionWindow windowQuest = new QuestionWindow();
                windowQuest.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Bitte wählen einen Fragebogen aus.");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded) 
            {
                var result = sender as ComboBox;
                var item = (ListBoxItem)result.SelectedItem;
                int id;
                if (int.TryParse(item.Content.ToString(), out id))
                {
                    this.data.FragebogenId = id;
                }
                
            }
        }
    }
}
