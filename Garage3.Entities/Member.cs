using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Garage3.Entities
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string PersonalNo { get; set; }
        
        [Range(18, 90)]
        public int Age { get; set; }

        public Name Name { get; set; }
         
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
