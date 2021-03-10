using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using Eumel.EmailCategorizer.Core.Model;
using Eumel.EmailCategorizer.Core.Ui;
using FluentAssertions;
using FontAwesome.Sharp;
using NUnit.Framework;

namespace Eumel.EmailCategorizer.Core.Tests.Ui
{
    [TestFixture]
    public class EumelMailSendControlTests
    {
        [Test]
        [Explicit]
        [Apartment(ApartmentState.STA)]
        public void ShowWindowAsDialog()
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

        [Test]
        [Apartment(ApartmentState.STA)]
        public void HasAddIcons()
        {
            var ctrl = new EumelMailSendControl()
            {
                Topics = new ObservableCollection<Topic>(Enumerable.Empty<Topic>())
            };
            ctrl.Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action(() => { }));

            ctrl.AddButton?.Content.Should().Be(IconChar.PlusSquare.ToChar());
        }

        [Test]
        [Ignore(reason: "Test data template for remove icon")]
        [Apartment(ApartmentState.STA)]
        public void HasRemoveIcons()
        {
            var ctrl = new EumelMailSendControl()
            {
                Topics = new ObservableCollection<Topic>(new[]
                {
                    new Topic { Title = "item1" }, new Topic { Title = "item2" },
                    new Topic { Title = "item3" }, new Topic { Title = "item4" }
                })
            };
            ctrl.Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action(() => { }));

            Assert.Inconclusive("Find controls in data template");
        }
    }
}