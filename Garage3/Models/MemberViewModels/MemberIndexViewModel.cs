using Garage3.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models.MemberViewModels
{
    public record MemberIndexViewModel(int Id, string PersonalNo, int Age, string NameFullName)
    {

    }
}
