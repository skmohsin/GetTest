using System.Linq;
using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Services.Enum;
using GetTest.Services.Implementation.DataBaseContext;
using GetTest.Services.Implementation.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GetTest.Services.Implementation
{
    class UserService : IUserService
    {
        private readonly GetTestDbContext _dbContext;
        public UserService(GetTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse> GetUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users != null
                    ? new ApiResponse { Data = new UserMapping().Map(users.AsQueryable()), Message = "Success", StatusCode = StatusCode.Ok }
                    : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }

        public async Task<ApiResponse> PostUserAsync(User user)
        {

            return null;
            //var result = await _dbContext.Users.AddAsync(user);
            //_dbContext.SaveChanges();
            //return result

        }
    }
}
