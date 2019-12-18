using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Entities;
using GetTest.Services.Enum;
using GetTest.Services.Implementation.DataBaseContext;
using GetTest.Services.Implementation.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GetTest.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly GetTestDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientService(GetTestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ApiResponse> GetPatientsAsync()
        {
            var patients = await _dbContext.Patients.ToListAsync();
            return patients != null
                   ? new ApiResponse { Data = _mapper.Map<IEnumerable<PatientDto>>(patients), Message = "Success", StatusCode = StatusCode.Ok }
                   : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }
        public async Task<ApiResponse> PostPatientAsync(PatientDto patient)
        {
            var postData = _mapper.Map<Patient>(patient);
            postData.CreatedBy = 1;
            postData.CreatedOn = DateTime.Now;
            _dbContext.Entry(postData).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            patient.PatientID = postData.PatientID;
            return new ApiResponse { Data = patient, Message = "Success", StatusCode = StatusCode.Created };
        }
        public async Task<ApiResponse> GetPatientByIdAsync(int patientID)
        {
            var patient = await _dbContext.Patients.Where(t => t.PatientID == patientID).SingleOrDefaultAsync();
            if (patient != null)
            {
                var tests = await _dbContext.Tests.Where(t => t.PatientID == patientID).ToListAsync();
                patient.Test = tests;
            }
            return patient != null
                   ? new ApiResponse { Data = _mapper.Map<PatientDto>(patient), Message = "Success", StatusCode = StatusCode.Ok }
                   : new ApiResponse { Data = null, Message = "Success", StatusCode = StatusCode.NoContent };
        }

        public async Task<ApiResponse> DeletePatientAsync(int patientID)
        {
            var patient = await _dbContext.Patients.Where(t => t.PatientID == patientID).SingleOrDefaultAsync();
            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                _dbContext.SaveChanges();
                return new ApiResponse { Message = $"Patient deleted successfully with id {patientID}", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"Patient not found with id {patientID}", StatusCode = StatusCode.NotFound };
            }
        }

        public async Task<ApiResponse> UpdatePatientAsync(int patientID, PatientDto patient)
        {
            var _test = await _dbContext.Patients.Where(t => t.PatientID == patientID).SingleOrDefaultAsync();
            if (_test != null)
            {
                var modifiedData = _mapper.Map<Patient>(patient);
                modifiedData.UpdatedBy = 1;
                modifiedData.CreatedOn = _test.CreatedOn;
                modifiedData.CreatedBy = _test.CreatedBy;
                modifiedData.UpdatedOn = DateTime.Now;
                _dbContext.Entry(_test).State = EntityState.Detached;
                _dbContext.Entry(modifiedData).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return new ApiResponse { Data = patient, Message = "Success", StatusCode = StatusCode.Ok };
            }
            else
            {
                return new ApiResponse { Message = $"Patient not found with id {patientID}", StatusCode = StatusCode.NotFound };
            }
        }
    }
}
