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
        [Test]
        public void IsTextCorrect()
        {
            Question q = new Question("Wie heißt die Hauptstadt Deutschlands?",
                                        new List<Answer>());

            string result = q.Text;

            Assert.AreEqual(result, "Wie heißt die Hauptstadt Deutschlands?");
        }
    }
}
