using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services;
using GetTest.Utilities.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTest.Api.Controllers.V1
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("api/v1/tests")]
        public async Task<IActionResult> GetTestAsync()
        {
            var response = await _testService.GetTestsAsync();
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("api/v1/test")]
        public async Task<IActionResult> PostTestAsync(TestDto test)
        {
            var response = await _testService.PostTestAsync(test);
            if (response.StatusCode == Services.Enum.StatusCode.Created)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("api/v1/test/{patientID}")]
        public async Task<IActionResult> GetTestByPatientIdAsync(int patientID)
        {
            var response = await _testService.GetTestByPatientIdAsync(patientID);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }

        [HttpDelete("api/v1/test/{testID}")]
        public async Task<IActionResult> DeleteTestAsync(int testID)
        {
            var response = await _testService.DeleteTestAsync(testID);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }

        [HttpPut("api/v1/test/{testID}")]
        public async Task<IActionResult> UpdateTestAsync(int testID, TestDto test)
        {
            var response = await _testService.UpdateTestAsync(testID, test);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }
    }
}