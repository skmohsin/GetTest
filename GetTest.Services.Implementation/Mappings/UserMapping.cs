using AutoMapper;
using GetTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTest.Services.Implementation.Mappings
{
    public class UserMapping : Profile
    {
        public UserDto Map(Entities.User source)
        {
            return source == null ? null : this.Map(new List<Entities.User> { source }.AsQueryable()).First();
        }
        public IQueryable<UserDto> Map(IQueryable<Entities.User> source)
        {
            return from s in source
                   select new UserDto
                   {
                       UserID = s.UserID,
                       Name = s.Name,
                       Mobile = s.Mobile,
                       Address = s.Address,
                       Degree = s.Degree,
                       RegistrationNumber = s.RegistrationNumber
                   };
        }
    }
}
