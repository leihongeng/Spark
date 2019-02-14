namespace Spark.Core.Values
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            IsSuccess = true;
            ErrorCode = string.Empty;
        }

        public BaseResponse(string msg)
        {
            Message = msg;
        }

        public bool IsSuccess { get; set; } = true;

        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(T data, bool isSuccess = true)
        {
            Data = data;
            base.IsSuccess = isSuccess;
        }

        public T Data { get; set; }
    }
}