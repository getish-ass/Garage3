#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Entities;

namespace Garage3.Data
{
    public class Garage3Context : DbContext
    {
        public DbSet<Garage3.Entities.Member> Member { get; set; }
        public DbSet<Garage3.Entities.Vehicle> Vehicle { get; set; }
        public Garage3Context (DbContextOptions<Garage3Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Name>()
                        .HasKey(n => new { n.MemberId });

            modelBuilder.Entity<Member>().Property(m => m.PersonalNo).IsRequired();

            modelBuilder.Entity<Vehicle>()
                        .HasKey(v => new { v.MemberId, v .VehicleTypeId} );

        }
    }
}
