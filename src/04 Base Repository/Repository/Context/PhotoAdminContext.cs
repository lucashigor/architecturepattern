﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PhotoAdminContext : DbContext
    {
        public PhotoAdminContext()
        {

        }

        public PhotoAdminContext(DbContextOptions<PhotoAdminContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\ItauSE4.mdf\";Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExamplePerson>(etd =>
            {
                etd.ToTable("TAB_EXAMPLE_PERSON");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasColumnName("PER_NAME").HasMaxLength(100);
                etd.Property(c => c.Cpf).HasColumnName("PER_CPF").HasMaxLength(11);
                etd.Property(c => c.BirthDate).HasColumnName("PER_BIRTHDATE").HasMaxLength(11);
            });

        }

        public virtual DbSet<ExamplePerson> ExamplePerson { get; set; }
    }
}
