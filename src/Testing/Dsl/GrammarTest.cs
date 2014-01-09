using System;
using System.Linq;
using Midwhay.Dsl;
using NUnit.Framework;
using Sprache;

namespace Midwhay.Testing.Dsl
{
    [TestFixture]
    public class GrammarTest
    {
        [Test]
        public void ParsesSimpleList()
        {
            var input = "LINK";
            var action = Grammar.Action.Parse(input);
            Assert.That(action, Is.EqualTo(ActionType.Link));
        }

        [Test]
        public void BracketTextReturnsAValueBetweenBrackets()
        {
            var input = "[Internet Sales]";
            var obj = Grammar.BracketTextual.Parse(input);
            Assert.That(obj, Is.EqualTo("Internet Sales"));
        }

        [Test]
        public void QualifierReturnsAQualifier()
        {
            var input = "FROM";
            var obj = Grammar.Qualifier.Parse(input);
            Assert.That(obj, Is.EqualTo(QualifierType.From));
        }

        [Test]
        public void SentenceReturnsASentence()
        {
            var input = "LINK FROM [Internet Sales];";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Link));
            Assert.That(s.Roles.ElementAt(0).Qualifier, Is.EqualTo(QualifierType.From));
            Assert.That(s.Roles.ElementAt(0).Objects.ElementAt(0), Is.EqualTo("Internet Sales"));
        }


        [Test]
        public void SentenceWithTwoObjectsReturnsASentence()
        {
            var input = "LINK FROM [Internet Sales], Product;";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Link));
            Assert.That(s.Roles.ElementAt(0).Qualifier, Is.EqualTo(QualifierType.From));
            Assert.That(s.Roles.ElementAt(0).Objects.ElementAt(0), Is.EqualTo("Internet Sales"));
            Assert.That(s.Roles.ElementAt(0).Objects.ElementAt(1), Is.EqualTo("Product"));
        }

        [Test]
        public void SentenceWithoutBracketsReturnsASentence()
        {
            var input = "JUNK TO Product;";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Junk));
            Assert.That(s.Roles.ElementAt(0).Qualifier, Is.EqualTo(QualifierType.To));
            Assert.That(s.Roles.ElementAt(0).Objects.ElementAt(0), Is.EqualTo("Product"));
        }

        [Test]
        public void SentenceWithTwoQualifiersReturnsASentence()
        {
            var input = "LINK FROM [Internet Sales] TO Product;";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Link));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.From));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Internet Sales"));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.To));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Product"));
        }

        [Test]
        public void SentenceWithTwoQualifiersWithTwoObjectsReturnsASentence()
        {
            var input = "LINK FROM [Internet Sales] TO Product, Promotion;";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Link));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.From));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Internet Sales"));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.To));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Product"));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Promotion"));
        }

        [Test]
        public void SentenceWithThreeQualifiersWithTwoObjectsReturnsASentence()
        {
            var input = "SNOWFLAKE\rFROM\r\t[Internet Sales]\rTHROUGH\r\t[Future Sales], Promotion\nTO\r\tProduct;";
            var s = Grammar.Sentence.Parse(input);
            Assert.That(s.Action, Is.EqualTo(ActionType.Snowflake));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.From));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.To));
            Assert.That(s.Roles, Has.Some.Property("Qualifier").EqualTo(QualifierType.Through));

            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Internet Sales"));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Future Sales"));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Promotion"));
            Assert.That(s.Roles, Has.Some.Property("Objects").Some.EqualTo("Product"));
        }

        [Test]
        public void TwoSentenceWithThreeQualifiersWithTwoObjectsReturnsTwoSentences()
        {
            var input = "LINK FROM [Internet Sales] TO Product, Promotion;";
            input += "SNOWFLAKE FROM [Internet Sales] THROUGH [Future Sales], Promotion TO Product;";
            var s = Grammar.Sentences.Parse(input);
            Assert.That(s, Has.Count.EqualTo(2));
        }
    }
}
