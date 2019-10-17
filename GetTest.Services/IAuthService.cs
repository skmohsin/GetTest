using GetTest.Contracts;
using GetTest.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetTest.Services
{
    public interface IAuthService
    {
        Task<ApiResponse> Authentication(AuthDto auth);
    }
}
