using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Eumel.Domse.BusinessLogic.Tests
{
    [TestFixture]
    public class DefaultAggregateSettingsProviderTest
    {
        [Test]
        public void Return_By_Order()
        {
            var avengers = Substitute.For<ISettingsProvider>();
            avengers.Order.Returns(1);
            avengers[Arg.Any<string>()].Returns((string)null);
            avengers[@"Spiderman"].Returns("Peter Parker");
            avengers[@"Iron Man"].Returns("Tony Stark");

            var fantasticFour = Substitute.For<ISettingsProvider>();
            fantasticFour[Arg.Any<string>()].Returns((string)null);
            fantasticFour.Order.Returns(2);
            fantasticFour[@"Human Torch"].Returns("Johnny Storm");

            var fullNameSettings = Substitute.For<ISettingsProvider>();
            fullNameSettings[Arg.Any<string>()].Returns((string)null);
            fullNameSettings.Order.Returns(3);
            fullNameSettings[@"Human Torch"].Returns("Jonathan Storm");
            fullNameSettings[@"Iron Man"].Returns("Anthony Stark");

            var sut = new DefaultAggregateSettingsProvider(new[] { avengers, fantasticFour, fullNameSettings });

            sut[@"Iron Man"].Should().Be("Tony Stark");
            sut[@"Human Torch"].Should().Be("Johnny Storm");
        }
        
        [Test]
        public void Provider_Can_Override_If_Earlier()
        {
            var avengers = Substitute.For<ISettingsProvider>();
            avengers.Order.Returns(1);
            avengers[Arg.Any<string>()].Returns((string)null);
            avengers[@"Spiderman"].Returns("Peter Parker");
            avengers[@"Iron Man"].Returns("Tony Stark");

            var fantasticFour = Substitute.For<ISettingsProvider>();
            fantasticFour[Arg.Any<string>()].Returns((string)null);
            fantasticFour.Order.Returns(2);
            fantasticFour[@"Human Torch"].Returns("Johnny Storm");

            var fullNameSettings = Substitute.For<ISettingsProvider>();
            fullNameSettings[Arg.Any<string>()].Returns((string)null);
            fullNameSettings.Order.Returns(0);
            fullNameSettings[@"Human Torch"].Returns("Jonathan Storm");
            fullNameSettings[@"Iron Man"].Returns("Anthony Stark");

            var sut = new DefaultAggregateSettingsProvider(new[] { avengers, fantasticFour, fullNameSettings });

            sut[@"Iron Man"].Should().Be("Anthony Stark");
            sut[@"Human Torch"].Should().Be("Jonathan Storm");
        }
    }
}
