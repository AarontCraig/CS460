namespace Homework8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }

        public virtual DbSet<ARTISTs> ARTISTs { get; set; }
        public virtual DbSet<ARTWORKs> ARTWORKs { get; set; }
        public virtual DbSet<CLASSIFICATIONs> CLASSIFICATIONs { get; set; }
        public virtual DbSet<GENREs> GENREs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTISTs>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ARTISTs>()
                .Property(e => e.BIRTHCITY)
                .IsUnicode(false);

            modelBuilder.Entity<ARTISTs>()
                .HasMany(e => e.ARTWORKs)
                .WithOptional(e => e.ARTIST1)
                .HasForeignKey(e => e.ARTIST);

            modelBuilder.Entity<ARTWORKs>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<ARTWORKs>()
                .HasMany(e => e.CLASSIFICATIONs)
                .WithRequired(e => e.ARTWORK1)
                .HasForeignKey(e => e.ARTWORK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENREs>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<GENREs>()
                .HasMany(e => e.CLASSIFICATIONs)
                .WithRequired(e => e.GENRE1)
                .HasForeignKey(e => e.GENRE)
                .WillCascadeOnDelete(false);
        }
    }
}
