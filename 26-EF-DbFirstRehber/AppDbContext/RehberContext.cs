using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _26_EF_DbFirstRehber.Models;

namespace _26_EF_DbFirstRehber.AppDbContext
{
    public partial class RehberContext : DbContext
    {
        public RehberContext()
        {
        }

        public RehberContext(DbContextOptions<RehberContext> options)
            : base(options)
        {

        }
        public virtual DbSet<TelefonRehberi> TelefonRehberis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KDK-403YZ-PC01;Database=Rehber;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelefonRehberi>(entity =>
            {
                entity.HasKey(e => e.KisiId)
                    .HasName("PK__TelefonR__110EDCE955879529");

                entity.ToTable("TelefonRehberi");

                entity.Property(e => e.KisiAdi).HasMaxLength(50);

                entity.Property(e => e.KisiSoyadi).HasMaxLength(50);

                entity.Property(e => e.KisiTelefon).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
