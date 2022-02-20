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
            CreateMap<Member, Models.MemberViewModels.MemberCreateViewModel>().ReverseMap();

        }
    }
}
