﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Garage3.Entities
{
    public class ParkingLot
    {
        public int Id { get; set; }
        
        public int ParkingNo { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
