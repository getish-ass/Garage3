using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Garage3.Entities
{
    public  class Vehicle
    {
        public int Id { get; set; }

        public string RegNo { get; set; }

        public string Model { get; set;  }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int NoWheels { get; set;  }

        public int MemberId { get; set; }
        public Member Member { get; set; }


        public VehicleType VehicleType { get; set; }

        public ICollection<ParkingLot> ParkingLot { get; set; }

    }
}
