#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public class MemberEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string PersonalNo { get; set; }
        public string NameFirstName { get; set; }
        public string NameLastName { get; set; }
        public int Age { get; set; }
    }
}
