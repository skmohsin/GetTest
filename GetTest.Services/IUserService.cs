using GetTest.Contracts;
using GetTest.Contracts.Response;
using System.Threading.Tasks;

namespace GetTest.Services
{
    public interface IUserService
    {
       
        Task<ApiResponse> GetUsersAsync();
        Task<ApiResponse> PostUserAsync(UserDto user);

        //Task<Doctor> GetDoctorByIdAsync(Guid postId);
        //Task<bool> CreateDoctorAsync(Doctor post);
        //Task<bool> UpdateDoctorAsync(Doctor postToUpdate);
        //Task<bool> DeleteDoctorAsync(Guid postId);
    }
}
