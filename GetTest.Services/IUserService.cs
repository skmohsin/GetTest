using GetTest.Contracts;
using GetTest.Contracts.Response;
using System.Threading.Tasks;

namespace GetTest.Services
{
    public interface IUserService
    {
        Task<ApiResponse> GetUsersAsync();
        Task<ApiResponse> PostUserAsync(UserDto user);
        Task<ApiResponse> DeleteUserAsync(int id);
        Task<ApiResponse> UpdateUserAsync(int id, UserDto user);
    }
}
