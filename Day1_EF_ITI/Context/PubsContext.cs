// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Day1_EF_ITI.Entities;

#nullable disable

namespace Day1_EF_ITI.Context
{
    public partial class PubsContext : DbContext
    {
        public PubsContext()
        {
        }

        public PubsContext(DbContextOptions<PubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=pubs;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.Property(e => e.PubId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName).IsUnicode(false);

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.PubId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Pubdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title1).IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UNDECIDED')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__titles__pub_id__1A14E395");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}