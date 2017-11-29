namespace Homework7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=Query")
        {
        }

        public virtual DbSet<Query> Queries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Query>()
                .Property(e => e.SearchQuery)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.SearchIP)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.SearchBrowser)
                .IsUnicode(false);
        }
    }
}
