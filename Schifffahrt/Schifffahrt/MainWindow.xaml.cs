﻿using System;
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

        public SharedData data;

        void initController()
        {
            Controller.sharedData = new SharedData();
        }
        public MainWindow()
        {
            InitializeComponent();
            initController();
            this.data = Controller.sharedData;
            DBConnection db = new DBConnection();
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
           
            if (cboFragebogen.SelectedIndex > 0)
            {
                App.initializeQuestions(this.data.FragebogenId);
                Controller.sharedData.Questionnaire = new Questionnaire(this.data.Questions, Schifffahrt.Properties.Settings.Default.PercentageToPass ,this.data.Answers);
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
