using GetTest.Services.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Contracts.Response
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Token { get; set; }
    }
}
