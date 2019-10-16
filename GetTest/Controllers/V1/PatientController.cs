using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTest.Api.Controllers.V1
{
    [ApiController]
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
            var patients = await _patService.GetPatientsAsync();
            return Ok(patients);
        }
    }
}