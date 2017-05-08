using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DIA.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Claim, ClaimHistory>();
           // CreateMap<ClaimHistory, Claim>();
        }
    }
}
