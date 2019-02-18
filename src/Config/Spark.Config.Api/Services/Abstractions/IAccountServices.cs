using Spark.Config.Api.DTO;
using Spark.Config.Api.Entity;

namespace Spark.Config.Api.Services.Abstractions
{
    public interface IAccountServices
    {
        User Login(LoginRequest request);
    }
}