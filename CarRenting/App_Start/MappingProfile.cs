using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CarRenting.Dtos;
using CarRenting.Models;

namespace CarRenting.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            
            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CarDto, Car>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}