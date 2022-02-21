using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Garage3.Entities
{
    public  class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(6)]
        public string RegNo { get; set; }

        [StringLength(20)]
        public string Model { get; set;  }

        [StringLength(30)]
        public string Brand { get; set; }
        
        [StringLength(10)]
        public string Color { get; set; }
        
        [Range(2, 16)] 
        public int NoWheels { get; set;  }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public ICollection<ParkingLot> ParkingLot { get; set; } = new List<ParkingLot>();

        public Vehicle()
        {

        }


        public Vehicle(string regNo, string model, string brand, string color, int noWheel)
        {
            RegNo = regNo;
            Model = model;
            Brand = brand;
            Color = color;
            NoWheels = noWheel;

        }






    }
}
