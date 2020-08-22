using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lib.io.Dtos;
using Lib.io.Models;

namespace Lib.io.App_Start {
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Automapper uses reflection to scan these types,
            // find their properties, and maps them based on their name
            // Two Way Mapping from Model <-> ModelDto
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<MemberDto, Member>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>().ForMember(b => b.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();

            Mapper.CreateMap<Borrowing, BorrowingDto>();
            Mapper.CreateMap<BorrowingDto, Borrowing>().ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}