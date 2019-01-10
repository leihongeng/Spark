using System.Threading.Tasks;

namespace Spark.AspNetCore.Middleware.Statistics
{
    public interface IGeolocationProvider
    {
        Task<IpInformation> GeolocateAsync(string ip);
    }
}