using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static void initializeQuestions()
        {
            DBConnection db = (DBConnection)App.Current.Properties["db"];
            MySqlCommand cmd = db.connection.CreateCommand();

            cmd.CommandText = "select * from t_sbf_binnen;";

            List<Question> questions = new List<Question>();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader["P_Id"];
                    var question = reader["Frage"] as string;
                    var answer1 = reader["Antwort1"] as string;
                    var answer2 = reader["Antwort2"] as string;
                    var answer3 = reader["Antwort3"] as string;
                    var answer4 = reader["Antwort4"] as string;
                    var right_answer_index = reader["RichtigeAntwort"];

                    List<Answer> answers = new List<Answer>();
                    answers.Add(new Answer(answer1));
                    answers.Add(new Answer(answer2));
                    answers.Add(new Answer(answer3));
                    answers.Add(new Answer(answer4));
                    
                    answers[Convert.ToInt32(right_answer_index) - 1].Set_Right();

                    Question q = new Question(Convert.ToInt32(id), question, answers);

                    questions.Add(q);
                }
            }

            App.Current.Properties["questions"] = questions;
        }

        public static void initializeQuestionnaire()
        {
            DBConnection db = (DBConnection)App.Current.Properties["db"];
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
