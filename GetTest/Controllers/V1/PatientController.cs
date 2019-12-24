using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetTest.Contracts;
using GetTest.Services;
using GetTest.Utilities.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTest.Api.Controllers.V1
{
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patService;

        public PatientController(IPatientService patService)
        {
            _patService = patService;
        }

        [HttpGet("api/v1/patients")]
        public async Task<IActionResult> GetDoctorAsync()
        {
            var response = await _patService.GetPatientsAsync();
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("api/v1/patient")]
        public async Task<IActionResult> PostpatientAsync(PatientDto patient)
        {
            var response = await _patService.PostPatientAsync(patient);
            if (response.StatusCode == Services.Enum.StatusCode.Created)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("api/v1/patient/{patientID}")]
        public async Task<IActionResult> GetpatientByPatientIdAsync(int patientID)
        {
            var response = await _patService.GetPatientByIdAsync(patientID);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("api/v1/patient/{patientID}")]
        public async Task<IActionResult> DeletepatientAsync(int patientID)
        {
            var response = await _patService.DeletePatientAsync(patientID);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }

        [HttpPut("api/v1/patient/{patientID}")]
        public async Task<IActionResult> UpdatepatientAsync(int patientID, PatientDto patient)
        {
            var response = await _patService.UpdatePatientAsync(patientID, patient);
            if (response.StatusCode == Services.Enum.StatusCode.Ok)
            {
                return Ok(response.RemoveNullKey());
            }
            return BadRequest(response.RemoveNullKey());
        }
    }
}