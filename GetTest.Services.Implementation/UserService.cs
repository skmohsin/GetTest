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
            await _dbContext.Users.AddAsync(_mapper.Map<User>(user));
            await _dbContext.SaveChangesAsync();
            user.UserID = user.UserID;
            return new ApiResponse { Data = user, Message = "Success", StatusCode = StatusCode.Created };
        }
    }
}

















//var users = _dbContext.Users.AsQueryable();
//var o = users.ProjectTo<UserDto>(configuration: _mapper.ConfigurationProvider);
//var revereseUsers = o.ProjectTo<User>(configuration: _mapper.ConfigurationProvider);

//return users != null
//        ? new ApiResponse { Data = users.ProjectTo<UserDto>(configuration: _mapper.ConfigurationProvider).ToList(), Message = "Success", StatusCode = StatusCode.Ok }
//        : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };