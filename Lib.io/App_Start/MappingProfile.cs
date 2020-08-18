using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lib.io.Dtos;
using Lib.io.Models;

namespace Lib.io.App_Start {
    public class MappingProfile : Profile{
        public MappingProfile() {
            // Automapper uses reflection to scan these types,
            // find their properties, and maps them based on their name
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<MemberDto, Member>();
        }
    }
}