using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Garage3.Entities
{
    public class Name
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";
    
        private Name()
        {
            FirstName = null!;
            LastName = null!;   
        }
        public Name(string firstName, string lastName)
        {   
            FirstName = firstName;
            LastName = lastName;
        }

        public int MemberId { get; set; }
        public Member Member { get; set; }


   





    }
}
