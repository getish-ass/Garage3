using System;
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
        
       

        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


        public ParkingLot()
        {
            
        }


        public ParkingLot(int typeName)
        {
           
        }


        public ParkingLot(int parkingNo, DateTime arrivalTime)
        {
           

        }


    }
}
