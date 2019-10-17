using Autofac;
using AutoMapper;
using GetTest.Contracts;
using GetTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Services.Implementation.Mappings
{
    public class Mapping
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserDto>().ReverseMap();

            });

            return new Mapper(config);
        }
    }
}
