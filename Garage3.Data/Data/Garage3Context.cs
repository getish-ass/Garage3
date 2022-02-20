#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Entities;
using Microsoft.Extensions.Logging;

namespace Garage3.Data
{
    public class Garage3Context : DbContext
    {
        public DbSet<Member> Member { get; set; }
       // public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Vehicle> VehicleType { get; set; }
        public Garage3Context (DbContextOptions<Garage3Context> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().Property<DateTime>("Edited");

            modelBuilder.Entity<VehicleType>()
                         .ToTable("VehicleType", c => c.IsTemporal());
           
            modelBuilder.Entity<Member>()
                        .OwnsOne(s => s.Name)
                        .Property(n => n.FirstName)
                        .HasColumnName("FirstName");

            modelBuilder.Entity<Member>()
                        .OwnsOne(s => s.Name)
                        .Property(n => n.LastName)
                        .HasColumnName("LastName");


            modelBuilder.Entity<VehicleType>().Property(c => c.TypeName).IsRequired();



            modelBuilder.Entity<Member>()
                        .HasMany(s => s.VehicleTypes)
                        .WithMany(c => c.Members)
                        .UsingEntity<Vehicle>(
                            e => e.HasOne(e => e.VehicleType).WithMany(c => c.Vehicles),
                            e => e.HasOne(e => e.Member).WithMany(s => s.Vehicles),
                            e => e.HasOne(e => e.ParkingLot)
                            );

        }












    }
}
