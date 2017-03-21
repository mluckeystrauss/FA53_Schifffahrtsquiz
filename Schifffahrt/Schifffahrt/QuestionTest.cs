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
        public void ArePropertiesCorrect()
        {
            Question q = new Question(5, "Wie heißt die Hauptstadt Deutschlands?",
                                        new List<Answer>());

            Assert.AreEqual(q.Text, "Wie heißt die Hauptstadt Deutschlands?");

            Assert.AreEqual(q.ID, 5);
        }
    }
}
