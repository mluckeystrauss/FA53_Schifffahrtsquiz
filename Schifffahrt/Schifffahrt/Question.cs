using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schifffahrt
{
    class Question
    {
        private string text;
        private List<Answer> answers;
        private bool is_answered;
        private int given_answer;

        /// <summary>
        /// Build a new Question with a text and answers
        /// </summary>
        /// <param name="text">The question itself as a string</param>
        /// <param name="answers">A List of possible answers for this question</param>
        public Question(string text, List<Answer> answers)
        {
            this.text = text;
            this.answers = answers;
            this.is_answered = false;
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
            get{ return given_answer; }
            set{ this.given_answer = value;}
        }

        /// <summary>
        /// Is true if this question has been answered right
        /// Is false if this question has been answered wrong or no answer has been given
        /// </summary>
        public bool Is_Answered_Right
        {
            get { return Is_Answered && answers[Given_Answer].Is_Right }  
        }
    }
}
