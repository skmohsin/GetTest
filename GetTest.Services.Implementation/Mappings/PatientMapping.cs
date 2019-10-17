using AutoMapper;
using GetTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTest.Services.Implementation.Mappings
{
    public class PatientMapping : Profile
    {
        public IQueryable<PatientDto> Map(IQueryable<Entities.Patient> source)
        {
            return from p in source
                   select new PatientDto
                   {
                       //Id = p.Id,
                       //Name = p.Name,
                       //Address = p.Address,
                       //Mobile = p.Mobile,
                       //Gender = p.Gender
                   };
        }
    }
}
