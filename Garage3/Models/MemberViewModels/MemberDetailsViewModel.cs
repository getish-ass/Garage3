#nullable disable
using Garage3.Entities;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string PersonalNo { get; set; }
        public string NameFirstName { get; set; }
        public string NameLastName { get; set; }
        public int Age { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}

