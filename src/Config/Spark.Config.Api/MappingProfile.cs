using AutoMapper;

namespace Spark.Config.Api
{
    public interface IProfile
    {
    }

    public class MappingProfile : Profile, IProfile
    {
        public MappingProfile()
        {
        }
    }
}