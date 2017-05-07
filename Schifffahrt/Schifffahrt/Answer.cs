using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schifffahrt
{
    public class Answer
    {
        private string text;
        private bool is_right;

        /// <summary>
        /// Builds a new Answer that is composed of a text and a boolean flag whether is answer
        /// is regarded right.
        /// </summary>
        /// <param name="text">The answer as string</param>
        /// <param name="is_right">True if answer is correct</param>
        public Answer(String text)
        {
            this.text = text;
            this.is_right = false;
        }


        /// <summary>
        /// The answer text.
        /// </summary>
        public string Text
        {
            get { return text; }
        }

        /// <summary>
        /// True if this answer is right
        /// </summary>
        public bool Is_Right
        {
            get { return is_right; }
        }

        public void Set_Right()
        {
            this.is_right = true;
        }
    }
}
