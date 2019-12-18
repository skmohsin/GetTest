using GetTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTest.Contracts.Response;

namespace GetTest.Services
{
    public interface IPatientService
    {
        Task<ApiResponse> GetPatientsAsync();
        Task<ApiResponse> PostPatientAsync(PatientDto patient);
        Task<ApiResponse> GetPatientByIdAsync(int id);
        Task<ApiResponse> DeletePatientAsync(int id);
        Task<ApiResponse> UpdatePatientAsync(int id, PatientDto patient);
    }
}
