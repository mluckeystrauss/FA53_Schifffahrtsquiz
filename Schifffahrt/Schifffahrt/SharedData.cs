using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Schifffahrt
{
    public class SharedData
    {
        private int _fragebogenid;

        public int FragebogenId
        {
            get { return _fragebogenid; }
            set { _fragebogenid = value; }
        }

        private List<Question> _questions;

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        private List<Answer> _answers;

        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        private Questionnaire _questionnaire;
        public Questionnaire Questionnaire
        {
            get
            {
                return _questionnaire;
            }
            set { _questionnaire = value; }
        }
    }
}
