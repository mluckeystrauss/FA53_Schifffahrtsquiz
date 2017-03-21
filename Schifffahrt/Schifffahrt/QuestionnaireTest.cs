using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Schifffahrt
{
    [TestFixture]
    class QuestionnaireTest
    {
        Questionnaire q;
        List<Question> questions;
        List<Answer> answers1;
        List<Answer> answers2;

        [SetUp]
        public void SetupQuestionnaire()
        {
            questions = new List<Question>();
            answers1 = new List<Answer>();

            answers1.Add(new Answer("Berlin"));
            answers1.Add(new Answer("Madrid"));
            answers1.Add(new Answer("Rom"));
            answers1.Add(new Answer("Castrop-Rauxel"));

            questions.Add( new Question(1, "Wie heißt die Hauptstadt Deutschlands?", answers1) );

            answers2 = new List<Answer>();

            answers2.Add(new Answer("Bad Oeynhausen"));
            answers2.Add(new Answer("London"));
            answers2.Add(new Answer("Stockholm"));
            answers2.Add(new Answer("Wien"));

            questions.Add(new Question(1, "Wie heißt die Hauptstadt Österreichs?", answers2));

            q = new Questionnaire(questions, "Fragebogen 1");
        }


        [Test]
        public void AreQuestionnairePropertiesCorrect()
        {
            Assert.AreEqual(2, q.Count);
            Assert.AreEqual("Fragebogen 1", q.Title);

            Assert.AreEqual(questions, q.Questions);
            Assert.AreEqual(questions[0], q.Current);

            Assert.AreEqual(0, q.Answered());
        }

        [Test]
        public void QuestionnaireFunctionsWorkCorrectly()
        {
            Assert.IsTrue(q.Next());

            Assert.AreEqual(questions[1], q.Current);

            Assert.IsFalse(q.Next());
            Assert.IsTrue(q.Previous());

            Assert.AreEqual(questions[0], q.Current);

            Assert.IsFalse(q.Previous());
        }
    }
}
