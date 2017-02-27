using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schifffahrt
{
    class Questionnaire
    {
        private List<Question> questions;
        private int current;

        /// <summary>
        /// A List with all questions
        /// </summary>
        public List<Question> Questions
        {
            get { return questions; }
        }

        /// <summary>
        /// Returns the current question
        /// </summary>
        public Question Current
        {
            get { return questions[current]; }
        }

        /// <summary>
        /// Sets the current question to the next question unless the current question is already the last one
        /// </summary>
        /// <returns>False if current question is the last question, true otherwise</returns>
        public bool Next()
        {
            if (current == questions.Count - 1) return false;
            current++;
            return true;
        }

        /// <summary>
        /// Sets the current question to the previous question unless the current question is already the first
        /// </summary>
        /// <returns>False if current question is the first question, false otherwise</returns>
        public bool Previous()
        {
            if (current == 0) return false;
            current--;
            return false;
        }

        /// <summary>
        /// Returns the number of already answered questions
        /// </summary>
        /// <returns>Returns the number of already answered questions</returns>
        public int Answered()
        {
            int sum = 0;

            foreach (Question q in questions)
                if (q.Is_Answered) 
                    sum++;

            return sum;
        }
    }
}
