using Eumel.Domse.PowerShell.Cmdlets;
using NUnit.Framework;
using Eumel.Domse.Core.Extensions;
using FluentAssertions;

namespace Eumel.Domse.PowerShell.Tests
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class TestDomeStoreCmdlet_Tests
    {
        [Test]
        public void Invoke_On_Real_Store()
        {
            var cmdlet = new TestDomseStoreCmdlet {Store = "C:\\Workspaces\\.EumelStore"};

            var foo = cmdlet.Invoke().Single<bool>();
            foo.Should().BeTrue();
        }
        
        [Test]
        public void Invoke_On_Wrong_Store()
        {
            var cmdlet = new TestDomseStoreCmdlet {Store = "C:\\Workspaces\\"};

            var foo = cmdlet.Invoke().Single<bool>();
            foo.Should().BeFalse();
        }
        
        [Test]
        public void Invoke_On_Non_Existing_Store()
        {
            var cmdlet = new TestDomseStoreCmdlet {Store = "C:\\Workspaces\\.I_Do_Not_Exist"};

            var foo = cmdlet.Invoke().Single<bool>();
            foo.Should().BeFalse();
        }
    }
}
