using GetTest.Contracts;
using GetTest.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetTest.Services
{
    public interface ITestService
    {
        Task<ApiResponse> GetTestsAsync();
        Task<ApiResponse> PostTestAsync(TestDto test);
        Task<ApiResponse> GetTestByPatientIdAsync(int id);
        Task<ApiResponse> DeleteTestAsync(int id);
        Task<ApiResponse> UpdateTestAsync(int id, TestDto test);
    }
}
