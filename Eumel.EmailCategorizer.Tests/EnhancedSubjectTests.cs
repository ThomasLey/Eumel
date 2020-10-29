using Eumel.EmailCategorizer.Persister;
using FluentAssertions;
using NUnit.Framework;

namespace Eumel.EmailCategorizer.Tests
{
    [TestFixture()]
    public class EnhancedSubjectTests
    {
        [Test]
        public void Parse_Subject_Without_Anything()
        {
            const string sampleSubject = "This is the subject";
            var sut = new EnhancedSubject(sampleSubject, new TopicParserConfiguration("[", "]"));

            sut.Subject.Should().Be("This is the subject");
        }

        [Test]
        public void Parse_Subject_With_Topic()
        {
            const string sampleSubject = "[TPC]This is the subject";
            var sut = new EnhancedSubject(sampleSubject, new TopicParserConfiguration("[", "]"));

            sut.Subject.Should().Be("This is the subject");
            sut.Topic.Title.Should().Be("TPC");
        }
    }
}