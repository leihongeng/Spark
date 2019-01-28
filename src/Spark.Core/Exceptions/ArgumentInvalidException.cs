namespace Spark.Core.Exceptions
{
    public class ArgumentInvalidException : SparkException
    {
        public ArgumentInvalidException(string message)
            : base("400", message)
        {
        }

        public ArgumentInvalidException()
            : base("参数错误！")
        {
        }
    }
}