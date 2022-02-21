#nullable disable
using Garage3.Validations;
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
        [NameAttribute]
        public string NameLastName { get; set; }
        
        [Range(18, 90)]
        public int Age { get; set; }

    }
}
