using AutoMapper;
using DTOs;
using Models;
using System;

namespace Services.Configs
{
    public static class MapperInitiator
    {
        /// <summary>
        /// Automapper initialization
        /// </summary>
        public static void InitializeMapper()
        {
            //**ENTITY to DTO Maps**
            Mapper.CreateMap<Dare, DareDTO>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key))
                .ForMember(x => x.User, y => y.MapFrom(x => x.From));
            Mapper.CreateMap<Response, ResponseDTO>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key))
                .ForMember(x => x.User, y => y.MapFrom(x => x.From));
            Mapper.CreateMap<Category, CategoryDTO>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key)); 
            Mapper.CreateMap<User, UserDTO>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key));

            //**DTO to ENTITY Maps**
            Mapper.CreateMap<DareDTO, Dare>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key));
            Mapper.CreateMap<ResponseDTO, Response>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key));
            Mapper.CreateMap<CategoryDTO, Category>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key));
            Mapper.CreateMap<UserDTO, User>()
                .ForMember(u => u.Key, e => e.MapFrom(u => u.Key == Guid.Empty ? Guid.NewGuid() : u.Key));

        }
    }
}
