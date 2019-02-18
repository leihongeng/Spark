using AutoMapper;
using Spark.Config.Api.AppCode;
using Spark.Config.Api.DTO.Service;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Implements
{
    public class ApiServices : IApiServices
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IPower _power;
        private readonly IMapper _mapper;

        public ApiServices(IServiceRepository serviceRepository
            , IPower power
            , IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _power = power;
            _mapper = mapper;
        }

        public QueryPageResponse<ApiServiceResponse> LoadList(ApiServiceSearchRequest request)
        {
            request.IsAdmin = _power.IsAdmin;
            request.UserId = _power.UserId;
            return _serviceRepository.GetList(request);
        }
    }
}