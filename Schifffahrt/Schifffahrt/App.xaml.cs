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

       
        
        public static void initializeQuestions(int fragebogenid)
        {
            DBConnection db = (DBConnection)Current.Properties["db"];

            
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

            

            Controller.sharedData.Questions = questions;
            Controller.sharedData.Answers = allAnswers;
            

           

            
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
