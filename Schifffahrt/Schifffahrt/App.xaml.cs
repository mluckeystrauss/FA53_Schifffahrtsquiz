using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using Schifffahrt.Model;
using Schifffahrt.Controller;
using Schifffahrt.Service;


namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

       
        
        public static void initializeQuestions(int fragebogenid)
        {
            DbConnectionService db = (DbConnectionService)Current.Properties["db"];

            
            DataTable dt = db.executeCommand("SELECT * FROM `t_sbf_binnen` join t_fragebogen_unter_maschine on F_Id_SBF_Binnen = p_id where fragebogennr = " + fragebogenid);

            List<Question> questions = new List<Question>();
            List<Answer> allAnswers = new List<Answer>();
            foreach (DataRow row in dt.Rows)
            {
                var rowHasNullValues = false;
                row.ItemArray.ToList().ForEach(obj => rowHasNullValues = obj == DBNull.Value);
                if (rowHasNullValues)
                {
                    continue;
                }

                List<Answer> answers = new List<Answer>();

                for (int i = 2; i <= 5; i++)
                {
                    answers.Add(new Answer(row[i].ToString()));
                }
                answers.ForEach(answer => allAnswers.Add(answer));
                answers[Convert.ToInt32(row["RichtigeAntwort"]) - 1].Set_Right();
                questions.Add(new Question(Convert.ToInt32((row["P_Id"])), row["Frage"].ToString(), answers));
            }



            SharedDataController.sharedData.Questions = questions;
            SharedDataController.sharedData.Answers = allAnswers;
        }

        public static void initializeQuestionsRadioOperator()
        {
            DbConnectionService db = (DbConnectionService)Current.Properties["db"];


            DataTable dt = db.executeCommand("SELECT * FROM `t_funk_ubi` join t_fragebogen_funk_ubi on F_id_Funk_UBI = Id");

            List<Question> questions = new List<Question>();
            List<Answer> allAnswers = new List<Answer>();
            foreach (DataRow row in dt.Rows)
            {
                var rowHasNullValues = false;
                row.ItemArray.ToList().ForEach(obj => rowHasNullValues = obj == DBNull.Value);
                if (rowHasNullValues)
                {
                    continue;
                }

                List<Answer> answers = new List<Answer>();

                for (int i = 2; i <= 5; i++)
                {
                    answers.Add(new Answer(row[i].ToString()));
                }
                answers.ForEach(answer => allAnswers.Add(answer));
                answers[0].Set_Right();
                questions.Add(new Question(Convert.ToInt32((row["Id"])), row["Frage"].ToString(), answers));
            }



            SharedDataController.sharedData.Questions = questions;
            SharedDataController.sharedData.Answers = allAnswers;
        }

        public static void initializeQuestionnaire()
        {
            DbConnectionService db = (DbConnectionService)App.Current.Properties["db"];
            MySqlCommand cmd = db.connection.CreateCommand();

            cmd.CommandText = "select * from t_fragebogen_unter_maschine;";

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                }
            }
        }
    }
}
