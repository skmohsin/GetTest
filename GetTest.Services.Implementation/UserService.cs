using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Entities;
using GetTest.Services.Enum;
using GetTest.Services.Implementation.DataBaseContext;
using GetTest.Services.Implementation.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GetTest.Services.Implementation
{
    class UserService : IUserService
    {
        private readonly GetTestDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(GetTestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse> GetUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users != null
                   ? new ApiResponse { Data = _mapper.Map<IEnumerable<UserDto>>(users), Message = "Success", StatusCode = StatusCode.Ok }
                   : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }

        public async Task<ApiResponse> PostUserAsync(UserDto user)
        {
            var postData = _mapper.Map<User>(user);
            postData.CreatedBy = 1;
            await _dbContext.Users.AddAsync(postData);
            await _dbContext.SaveChangesAsync();
            user.UserID = postData.UserID;
            return new ApiResponse { Data = user, Message = "Success", StatusCode = StatusCode.Created };
        }

        public async Task<ApiResponse> DeleteUserAsync(int userID)
        {
            var user = await _dbContext.Users.Where(u => u.UserID == userID).SingleOrDefaultAsync();
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return new ApiResponse { Message = $"User deleted successfully with id {userID}", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"User not found with id {userID}", StatusCode = StatusCode.NotFound };
            }
        }

        public async Task<ApiResponse> UpdateUserAsync(int userID, UserDto user)
        {
            var _user = await _dbContext.Users.Where(u => u.UserID == userID).SingleOrDefaultAsync();
            if (_user != null)
            {
                var modifiedData = _mapper.Map<User>(user);
                await _dbContext.Users.AddAsync(modifiedData);
                await _dbContext.SaveChangesAsync();
                return new ApiResponse { Data = user, Message = "Success", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"User not found with id {userID}", StatusCode = StatusCode.NotFound };
            }
        }
    }
}






//using (var context = new SchoolDBEntities())
//{
    //context.Entry(student).State = student.StudentId == 0? EntityState.Added : EntityState.Modified;

    //context.SaveChanges();
//}



//var users = _dbContext.Users.AsQueryable();
//var o = users.ProjectTo<UserDto>(configuration: _mapper.ConfigurationProvider);
//var revereseUsers = o.ProjectTo<User>(configuration: _mapper.ConfigurationProvider);

//return users != null
//        ? new ApiResponse { Data = users.ProjectTo<UserDto>(configuration: _mapper.ConfigurationProvider).ToList(), Message = "Success", StatusCode = StatusCode.Ok }
//        : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };