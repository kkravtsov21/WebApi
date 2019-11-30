using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblGroups> TblGroups { get; set; }
        public virtual DbSet<TblStudents> TblStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=c:\\sqlite\\test.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGroups>(entity =>
            {
                entity.ToTable("tblGroups");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int IDENTITY(1,1)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblStudents>(entity =>
            {
                entity.ToTable("tblStudents");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int IDENTITY(1,1)")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasColumnName("Group_id")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
