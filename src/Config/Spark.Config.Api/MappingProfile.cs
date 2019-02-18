using AutoMapper;
using Spark.Config.Api.DTO.App;
using Spark.Config.Api.DTO.Config;
using Spark.Config.Api.DTO.Sms;
using Spark.Config.Api.DTO.User;
using Spark.Config.Api.Entity;

namespace Spark.Config.Api
{
    public interface IProfile
    {
    }

    public class MappingProfile : Profile, IProfile
    {
        public MappingProfile()
        {
            CreateMap<AppRequest, App>();

            CreateMap<UserRequest, User>();
            CreateMap<SmsTempRequest, SmsTemp>();

            CreateMap<ConfigRequest, Entity.Config>();
        }
    }
}