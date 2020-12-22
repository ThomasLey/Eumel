using System.Collections.ObjectModel;
using System.Threading;
using Eumel.EmailCategorizer.Core.Model;
using Eumel.EmailCategorizer.Core.Ui;
using NUnit.Framework;

namespace Eumel.EmailCategorizer.Core.Tests
{
    [TestFixture]
    public class EumelMailSendControlTests
    {
        [Test]
        [Explicit]
        [Apartment(ApartmentState.STA)]
        public void IsCreatable()
        {
            var ctrl = new EumelMailSendControl()
            {
                Topics = new ObservableCollection<Topic>(new[]
                {
                    new Topic { Title = "item1" }, new Topic { Title = "item2" },
                    new Topic { Title = "item3" }, new Topic { Title = "item4" }
                })
            };

            ctrl.ShowModel("demo");
        }
    }
}