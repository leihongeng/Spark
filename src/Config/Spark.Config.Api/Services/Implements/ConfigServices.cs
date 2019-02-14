using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spark.Config.Api.DTO.Config;
using Spark.Config.Api.Repository;
using Spark.Config.Api.Services.Abstractions;
using Spark.Core.Values;

namespace Spark.Config.Api.Services.Implements
{
    public class ConfigServices : IConfigServices
    {
        private readonly IConfigRepository _configRepository;

        public ConfigServices(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public QueryPageResponse<ConfigResponse> LoadList(KeywordQueryPageRequest request)
        {
            return _configRepository.GetList(request);
        }
    }
}