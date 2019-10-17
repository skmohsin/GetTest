using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Services.Implementation.Mappings;

namespace GetTest.Services.Implementation
{
    public class PatientService : IPatientService
    {
        public async Task<ApiResponse> GetPatientsAsync()
        {
            return null;
        }
    }
}
