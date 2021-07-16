using System;
using System.Data.Entity;
using System.Linq;
using Eumel.Domse.Database.Entity;
using FluentAssertions;
using NUnit.Framework;

namespace Eumel.Domse.Database.Tests
{
    [TestFixture]
    public class ContextTest
    {
        [Test]
        public void Foo1()
        {
            using var ctx = new DomseDbContext();

            foreach (var document in ctx.Document.Include(nameof(Document.DocumentProperties)))
            {
                Console.WriteLine($"[{document.Id}] {document.Source}");
                foreach (var property in document.DocumentProperties)
                    Console.WriteLine($"  [{property.Id}] {property.OriginalKey} = {property.Value} ({property.Document.Id})");
            }
        }

        [Test]
        public void Foo11()
        {
            using var ctx = new DomseDbContext();

            var doc = ctx.Document.First();
            ctx.Document.Remove(doc);
            ctx.SaveChanges();
        }

        public static int[] TestCases { get; } = Enumerable.Range(1, 200).ToArray();

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Foo2(int number)
        {
            var doc = new Document() {Source = "\\"};
            doc.DocumentProperties.Add(new DocumentProperty()
            {
                OriginalKey = $"Title {number}",
                Value = $"My Document at {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}"
            });
            doc.DocumentProperties.Add(new DocumentProperty()
            {
                OriginalKey = "Author",
                Value = $"{Environment.UserName}"
            });
            // all these fields are set by the EF during save
            doc.DocumentProperties.First().Document.Should().BeNull();
            doc.DocumentProperties.First().Id.Should().BeEmpty();
            doc.Id.Should().BeEmpty();

            using var ctx = new DomseDbContext();

            ctx.Document.Add(doc);
            ctx.SaveChanges();

            // save changes these values automatically
            doc.DocumentProperties.First().Document.Should().NotBeNull();
            doc.DocumentProperties.First().Id.Should().NotBeEmpty();
            doc.Id.Should().NotBeEmpty();
        }

        [Test]
        [Explicit(reason: "This drops the entire data")]
        public void Foo3()
        {
            using var ctx = new DomseDbContext();

            ctx.Database.Delete();
            ctx.Database.Create();
        }
    }
}
