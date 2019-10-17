using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services.Implementation.Mappings;

namespace GetTest.Services.Implementation
{
    public class PatientService : IPatientService
    {
        public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
        {
            var patients = new List<Entities.Patient>();
            for (int i = 0; i < 5; i++)
            {
                patients.Add(
                    new Entities.Patient
                    {
                        //PatientID = Guid.NewGuid(),
                        //Name = $"Name {i}",
                        //Mobile = $"Mobile {i}",
                        //Address = $"Address {i}",
                        //Gender = $"Gender {i}"
                    });
            }
            return patients != null ? new PatientMapping().Map(patients.AsQueryable()) : null;
        }
    }
}
