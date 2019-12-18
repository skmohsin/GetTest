using AutoMapper;
using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Entities;
using GetTest.Services.Enum;
using GetTest.Services.Implementation.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTest.Services.Implementation
{
    public class TestService : ITestService
    {
        private readonly GetTestDbContext _dbContext;
        private readonly IMapper _mapper;

        public TestService(GetTestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ApiResponse> GetTestsAsync()
        {
            var tests = await _dbContext.Tests.ToListAsync();
            return tests != null
                   ? new ApiResponse { Data = _mapper.Map<IEnumerable<TestDto>>(tests), Message = "Success", StatusCode = StatusCode.Ok }
                   : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }

        public async Task<ApiResponse> PostTestAsync(TestDto test)
        {
            var postData = _mapper.Map<Test>(test);
            postData.CreatedBy = 1;
            postData.CreatedOn = DateTime.Now;
            _dbContext.Entry(postData).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            test.TestID = postData.TestID;
            return new ApiResponse { Data = test, Message = "Success", StatusCode = StatusCode.Created };
        }

        public async Task<ApiResponse> DeleteTestAsync(int testID)
        {
            var test = await _dbContext.Tests.Where(t => t.TestID == testID).SingleOrDefaultAsync();
            if (test != null)
            {
                _dbContext.Tests.Remove(test);
                _dbContext.SaveChanges();
                return new ApiResponse { Message = $"Test deleted successfully with id {testID}", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"Test not found with id {testID}", StatusCode = StatusCode.NotFound };
            }
        }

        public async Task<ApiResponse> UpdateTestAsync(int testID, TestDto test)
        {
            var _test = await _dbContext.Tests.Where(t => t.TestID == testID).SingleOrDefaultAsync();
            if (_test != null)
            {
                var modifiedData = _mapper.Map<User>(test);
                modifiedData.UpdatedBy = 1;
                modifiedData.CreatedOn = _test.CreatedOn;
                modifiedData.CreatedBy = _test.CreatedBy;
                modifiedData.UpdatedOn = DateTime.Now;
                _dbContext.Entry(_test).State = EntityState.Detached;
                _dbContext.Entry(modifiedData).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return new ApiResponse { Data = test, Message = "Success", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"Test not found with id {testID}", StatusCode = StatusCode.NotFound };
            }
        }

        public async Task<ApiResponse> GetTestByPatientIdAsync(int patientID)
        {
            var tests = await _dbContext.Tests.Where(t => t.PatientID == patientID).ToListAsync();
            return tests != null
                   ? new ApiResponse { Data = _mapper.Map<IEnumerable<TestDto>>(tests), Message = "Success", StatusCode = StatusCode.Ok }
                   : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }
    }
}
