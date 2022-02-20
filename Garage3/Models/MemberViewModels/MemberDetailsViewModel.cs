#nullable disable
using Garage3.Entities;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Personal Number")]
        public string PersonalNo { get; set; }

        [Display(Name = "First Name")]
        public string NameFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string NameLastName { get; set; }
     
        public int Age { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}

