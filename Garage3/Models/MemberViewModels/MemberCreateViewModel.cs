#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public class MemberCreateViewModel
    {

        [Required]
        [Display(Name ="Personal Number")]
        public string PersonalNo { get; set; }

        [Display(Name = "First Name")]
        public string NameFirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string NameLastName { get; set; } 
        public int Age { get; set; }

    }
}
