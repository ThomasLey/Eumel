using System;
using System.Data.Entity;

namespace Eumel.Domse.Database.Entity
{
    public class DomseDbContext : DbContext
    {
        public DomseDbContext()
        {
            Database.Log = Console.WriteLine;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasMany(s => s.DocumentProperties)
                .WithRequired()
                .WillCascadeOnDelete(true);
        }

        public IDbSet<Document> Document => Set<Document>();
    }
}