using Eumel.EmailCategorizer.Extensions;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Eumel.EmailCategorizer.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        [TestCase("hello [world] thomas", "world", "[", "]")]
        [TestCase("hello ]world[ thomas", "world", "[", "]")]
        [TestCase("hello world thomas", "", "[", "]")]
        [TestCase("[hello world thomas", "", "[", "]")]
        [TestCase("hello world] thomas", "", "[", "]")]
        [TestCase("hello |world| thomas", "world", "|", "|")]
        [TestCase("hello world", "", null, null)]
        [TestCase("hello world", "", "", "")]
        [TestCase("", "", "[", "]")]
        [TestCase("[]", "", "[", "]")]
        [TestCase(null, null, null, null)]
        public void BetweenTest(string test, string expected, string topicStart, string topicEnd)
        {
            var actual = test.Between(topicStart, topicEnd);

            actual.Should().Be(expected);
        }
    }
}