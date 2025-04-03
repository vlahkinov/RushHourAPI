using Microsoft.EntityFrameworkCore;
using Prime.RushHourAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prime.RushHourAPI.Data
{
    public class RushHourAPIDbContext : DbContext
    {
        public RushHourAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> Activities{ get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<ActivityAppointment> ActivityAppointments { get; set; }
        public DbSet<ActivityEmployee> ActivityEmployee { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasIndex(u => u.FullName).IsUnique();
            modelBuilder.Entity<Account>().
                HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Provider>()
                .HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Account>()
           .HasOne(b => b.Client)
           .WithOne(i => i.Account)
           .HasForeignKey<Client>(b => b.AccountId);

            modelBuilder.Entity<Account>()
          .HasOne(b => b.Employee)
          .WithOne(i => i.Account)
          .HasForeignKey<Employee>(b => b.AccountId);

            modelBuilder.Entity<Appointment>()
           .HasOne(b => b.Employee)
           .WithOne(i => i.Appointment)
           .HasForeignKey<Appointment>(b => b.EmployeeId)
           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ActivityEmployee>(entity =>
            {
                entity.HasOne(c => c.Activity)
                    .WithMany(e => e.ActivityEmployees)
                    .HasForeignKey(c => c.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ActivityEmployee>(entity =>
            {
                entity.HasOne(c => c.Employee)
                    .WithMany(e => e.ActivityEmployees)
                    .HasForeignKey(c => c.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });



            modelBuilder
        .Entity<Provider>()
        .Property(e => e.WorkingDays)
        .HasConversion(
            v => string.Join(", ", v),
            v => v.Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), x)).ToList());
        }
    }
}
