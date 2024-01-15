using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models
{
    public partial class EmployeeContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public EmployeeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;

        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<TblCity> TblCities { get; set; } = null!;
        public virtual DbSet<TblCountry> TblCountries { get; set; } = null!;
        public virtual DbSet<TblState> TblStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hobbies)
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus).HasColumnName("Marital Status");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.TblCountry)
                      .WithMany(e => e.Employees)
                      .HasForeignKey(d => d.Country)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Country");

                entity.HasOne(d => d.TblState)
                      .WithMany(e => e.Employees)
                      .HasForeignKey(d => d.State)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_State");

                entity.HasOne(d => d.TblCity)
                      .WithMany(e => e.Employees)
                      .HasForeignKey(d => d.City)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_City");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {

                entity.ToTable("tbl_cities");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.State)
                    .WithMany(e => e.TblCities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.ToTable("tbl_countries");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Sortname)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sortname");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.ToTable("tbl_states");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblStates)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
