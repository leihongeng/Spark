using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.Core.Values
{
    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse(string code, string msg)
        {
            IsSuccess = false;
            Message = msg;
            ErrorCode = code;
        }
    }
}