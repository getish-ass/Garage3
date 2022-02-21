using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Garage3.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        public int TypeCode { get; set; }
        
        public string TypeName { get; set; }

        public int Size { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public ICollection<Member> Members { get; set; }



        public VehicleType()
        {
            
        }



        public VehicleType(int typeCode)
        {
            TypeCode = typeCode;
        }


        public VehicleType(int typeCode, string typeName, int size)
        {
            TypeCode = typeCode;
            TypeName = typeName;
            Size = size;

        }






    }

}
