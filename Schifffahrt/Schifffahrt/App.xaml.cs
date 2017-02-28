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
            DBConnection db = (DBConnection)Current.Properties["db"];
            MySqlCommand cmd = db.connection.CreateCommand();

            cmd.CommandText = "select * from t_sbf_binnen;";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd.CommandText,db.connection);

            DataSet ds = new DataSet();

            da.Fill(ds, "t_sbf_binnen");

            DataTable dt = ds.Tables["t_sbf_binnen"];
            List<Question> questions = new List<Question>();
            
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
                answers[Convert.ToInt32(row["RichtigeAntwort"]) - 1].Set_Right();
                questions.Add(new Question(Convert.ToInt32((row["P_Id"])), row["Frage"].ToString(), answers));
            }

            foreach (Question quest in questions)
            {
                string answers = "";
                quest.Answers.ForEach(answer => answers += answer.Text + " ");
                MessageBox.Show("Frage: " + quest.Text + "  " + answers);
            }

           

            
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
