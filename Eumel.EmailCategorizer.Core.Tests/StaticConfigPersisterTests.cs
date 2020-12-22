using Eumel.EmailCategorizer.Core.Model;
using FluentAssertions;
using NUnit.Framework;

namespace Eumel.EmailCategorizer.Core.Tests
{
    [TestFixture]
    public class StaticConfigPersisterTests
    {
        [Test]
        public void IsCreatable()
        {
            var sut = new StaticConfigPersister();
            sut.Should().BeAssignableTo<IConfigPersister>();
        }

        [Test]
        public void ReadConfig()
        {
            var sut = new StaticConfigPersister();

            var cfg = sut.GetConfig();
            cfg.TopicStart.Should().Be("[");
            cfg.TopicEnd.Should().Be("]");
        }

        [Test]
        public void ReadImmutableConfig()
        {
            var sut = new StaticConfigPersister();

            var cfg = sut.GetConfig();
            cfg.TopicStart.Should().Be("[");
            cfg.TopicEnd.Should().Be("]");

            sut.SetConfig(new TopicParserConfiguration("(", ")"));

            cfg = sut.GetConfig();
            cfg.TopicStart.Should().Be("[");
            cfg.TopicEnd.Should().Be("]");
        }
    }
}