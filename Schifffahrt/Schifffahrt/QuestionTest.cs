using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Schifffahrt
{
    [TestFixture]
    class QuestionTest
    {
        Question q;
        List<Answer> answers;

        [SetUp]
        public void SetupQuestion()
        {
            answers = new List<Answer>();

            answers.Add( new Answer("Berlin") );
            answers.Add( new Answer("Madrid") );
            answers.Add( new Answer("Rom") );
            answers.Add( new Answer("Castrop-Rauxel") );

            q = new Question(5, "Wie heißt die Hauptstadt Deutschlands?", answers);
        }


        [Test]
        public void ArePropertiesCorrect()
        {
            Question q = new Question(5, "Wie heißt die Hauptstadt Deutschlands?",
                                        answers );

            Assert.AreEqual(q.Text, "Wie heißt die Hauptstadt Deutschlands?");
            Assert.AreEqual(q.ID, 5);
            Assert.AreEqual(q.Answers, answers);

            Assert.IsFalse(q.Is_Answered);
        }
    }
}
