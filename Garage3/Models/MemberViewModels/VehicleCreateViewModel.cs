using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public class VehicleCreateViewModel
    {

        [Required]
        [StringLength(6)]
        public string RegNo { get; set; }

        [StringLength(20)]
        public string Model { get; set; }

        [StringLength(30)]
        public string Brand { get; set; }

        [StringLength(10)]
        public string Color { get; set; }

        [Range(2, 16)]
        public int NoWheels { get; set; }

        public int MemberId { get; set; }

        public int VehicleTypeId { get; set; }

        public IEnumerable<SelectListItem> Members { get; set; }
        public IEnumerable<SelectListItem> VehicleTypes { get; set; } 

    }

}
        