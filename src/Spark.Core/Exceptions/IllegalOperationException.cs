using System;

namespace Micro.Core.Exceptions
{
    public class IllegalOperationException : SparkException
    {
        public IllegalOperationException()
            : base("操作不合法！")
        {

        }

        public IllegalOperationException(string message)
            : base(message)
        {
        }

        public IllegalOperationException(string code, string message)
            : base(code, message)
        {
        }

        public IllegalOperationException(string code, string message, Exception exception)
            : base(code, message, exception)
        {
        }
    }
}
