using AutoMapper;
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
            CreateMap<UserRequest, User>();
            CreateMap<SmsTempRequest, SmsTemp>();
        }
    }
}