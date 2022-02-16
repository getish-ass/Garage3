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
    }

}
