using System;
using System.Collections.Generic;
using System.Text;

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

    public class QueryResponse<T>
    {
        public IEnumerable<T> List { get; set; }
    }

    public class QueryByPageResponse<T> : QueryResponse<T>
    {
        public long Total { get; set; }
    }

    public class QueryByPageRequest
    {
        private int _pageIndex;

        public int PageIndex
        {
            get
            {
                return _pageIndex <= 0 ? 1 : _pageIndex;
            }
            set
            {
                if (value <= 0)
                    _pageIndex = 1;
                else
                    _pageIndex = value;
            }
        }

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value >= 100)
                {
                    pageSize = 100;
                }
                else if (value <= 0)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = value;
                }
            }
        }

        public int Offset { get { return (PageIndex - 1) * PageSize; } }
    }
}