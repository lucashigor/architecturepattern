﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Repository
{
    public class SE4Context : DbContext
    {
        public SE4Context()
        {

        }

        public SE4Context(DbContextOptions<SE4Context> options)
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
