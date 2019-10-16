using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Services.Enum
{
    public enum StatusCode
    {
        Created = 201,
        Ok = 200,
        NoContent = 204,
        BadRequest = 400,
        UnAuthorized = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}
