namespace Homework8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Art : DbContext
    {
        public Art()
            : base("name=Art")
        {
        }

        public virtual DbSet<ARTIST> ARTISTs { get; set; }
        public virtual DbSet<ARTWORK> ARTWORKs { get; set; }
        public virtual DbSet<CLASSIFICATION> CLASSIFICATIONs { get; set; }
        public virtual DbSet<GENRE> GENREs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTIST>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ARTIST>()
                .Property(e => e.BIRTHCITY)
                .IsUnicode(false);

            modelBuilder.Entity<ARTIST>()
                .HasMany(e => e.ARTWORKs)
                .WithOptional(e => e.ARTIST1)
                .HasForeignKey(e => e.ARTIST);

            modelBuilder.Entity<ARTWORK>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<ARTWORK>()
                .HasMany(e => e.CLASSIFICATIONs)
                .WithRequired(e => e.ARTWORK1)
                .HasForeignKey(e => e.ARTWORK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENRE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.CLASSIFICATIONs)
                .WithOptional(e => e.GENRE1)
                .HasForeignKey(e => e.GENRE);
        }
    }
}
