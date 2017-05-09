using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Schifffahrt.Model;

namespace Schifffahrt.Model
{
    public class Question
    {
        private int id;
        private string text;
        private List<Answer> answers;
        private bool is_answered;
        private int given_answer = 1;

        /// <summary>
        /// Build a new Question with a text and answers
        /// </summary>
        /// <param name="text">The question itself as a string</param>
        /// <param name="answers">A List of possible answers for this question</param>
        public Question(int id, string text, List<Answer> answers)
        {
            this.id = id;
            this.text = text;
            this.answers = answers;
            this.is_answered = false;
        }

        public int ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// The Question itself as a string
        /// </summary>
        public string Text
        {
            get { return text; }
        }

        /// <summary>
        /// A List of Answer objects
        /// </summary>
        public List<Answer> Answers
        {
            get { return answers; }
        }

        /// <summary>
        /// True if an answer has already been given to this question
        /// </summary>
        public bool Is_Answered
        {
            get { return is_answered; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public int Given_Answer
        {
            get { return given_answer; }
            set
            {
                this.is_answered = true;
                this.given_answer = value;

            }
        }

        /// <summary>
        /// Is true if this question has been answered right
        /// Is false if this question has been answered wrong or no answer has been given
        /// </summary>
        public bool Is_Answered_Right
        {
            get { return Is_Answered && answers[Given_Answer - 1].Is_Right; }
        }

        public string to_string()
        {
            return this.text + "\na) " + this.answers[0].Text
                             + "\nb) " + this.answers[1].Text
                             + "\nc) " + this.answers[2].Text
                             + "\nd) " + this.answers[3].Text;
        }

        public string Right_Answer_Text
        {
            get
            {
                return this.answers.Find(match => match.Is_Right).Text;
            }
        }
    }
}
