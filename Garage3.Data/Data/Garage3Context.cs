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
        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<VehicleType> VehicleType { get; set; }

        public DbSet<ParkingLot> ParkingLot { get; set; }

        public Garage3Context (DbContextOptions<Garage3Context> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

       








    }
}
