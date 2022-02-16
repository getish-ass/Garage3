﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Garage3.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string PersonalNo { get; set; }
        public int Age { get; set; }

        public Name Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
