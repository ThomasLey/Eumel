using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Eumel.Domse.BusinessLogic.Tests
{
    [TestFixture]
    public class DefaultAggregateConfigProviderTest
    {
        [Test]
        public void Return_By_Order()
        {
            var avengers = Substitute.For<IConfigProvider>();
            avengers.Order.Returns(1);
            avengers[Arg.Any<string>()].Returns((string)null);
            avengers[@"Spiderman"].Returns("Peter Parker");
            avengers[@"Iron Man"].Returns("Tony Stark");

            var fantasticFour = Substitute.For<IConfigProvider>();
            fantasticFour[Arg.Any<string>()].Returns((string)null);
            fantasticFour.Order.Returns(2);
            fantasticFour[@"Human Torch"].Returns("Johnny Storm");

            var fullNameConfig = Substitute.For<IConfigProvider>();
            fullNameConfig[Arg.Any<string>()].Returns((string)null);
            fullNameConfig.Order.Returns(3);
            fullNameConfig[@"Human Torch"].Returns("Jonathan Storm");
            fullNameConfig[@"Iron Man"].Returns("Anthony Stark");

            var sut = new DefaultAggregateConfigProvider(new[] { avengers, fantasticFour, fullNameConfig });

            sut[@"Iron Man"].Should().Be("Tony Stark");
            sut[@"Human Torch"].Should().Be("Johnny Storm");
        }
        
        [Test]
        public void Provider_Can_Override_If_Earlier()
        {
            var avengers = Substitute.For<IConfigProvider>();
            avengers.Order.Returns(1);
            avengers[Arg.Any<string>()].Returns((string)null);
            avengers[@"Spiderman"].Returns("Peter Parker");
            avengers[@"Iron Man"].Returns("Tony Stark");

            var fantasticFour = Substitute.For<IConfigProvider>();
            fantasticFour[Arg.Any<string>()].Returns((string)null);
            fantasticFour.Order.Returns(2);
            fantasticFour[@"Human Torch"].Returns("Johnny Storm");

            var fullNameConfig = Substitute.For<IConfigProvider>();
            fullNameConfig[Arg.Any<string>()].Returns((string)null);
            fullNameConfig.Order.Returns(0);
            fullNameConfig[@"Human Torch"].Returns("Jonathan Storm");
            fullNameConfig[@"Iron Man"].Returns("Anthony Stark");

            var sut = new DefaultAggregateConfigProvider(new[] { avengers, fantasticFour, fullNameConfig });

            sut[@"Iron Man"].Should().Be("Anthony Stark");
            sut[@"Human Torch"].Should().Be("Jonathan Storm");
        }
    }
}
