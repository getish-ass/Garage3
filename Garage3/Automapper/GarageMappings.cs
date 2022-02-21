using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Garage3.Entities;

namespace Garage3.Automapper
{
   public class GarageMappings : Profile
    {
        public GarageMappings()
        {
            CreateMap<Member, MemberCreateViewModel>().ReverseMap();
            CreateMap<Member, MemberEditViewModel>().ReverseMap();
            CreateMap<Member, MemberIndexViewModel>();
            CreateMap<Member, MemberDetailsViewModel>()
                .ForMember(
                    dest => dest.Vehicles,
                    from => from.MapFrom(v => v.Vehicles.Count));

        }
    }
}
