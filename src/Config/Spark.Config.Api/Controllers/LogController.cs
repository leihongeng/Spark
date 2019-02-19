using Microsoft.AspNetCore.Mvc;
using Nest;
using Spark.Config.Api.DTO.Log;
using Spark.Core.Values;
using Spark.Elasticsearch;
using System;
using System.Collections.Generic;

namespace Spark.Config.Api.Controllers
{
    public class LogController : BaseController
    {
        private readonly IElasticClientFactory _elasticClientFactory;

        public LogController(IElasticClientFactory elasticClientFactory)
        {
            _elasticClientFactory = elasticClientFactory;
        }

        [HttpGet]
        public IActionResult List([FromQuery]LogSearchRequest model)
        {
            SearchRequest searchRequest = new SearchRequest();
            BoolQuery boolQuery = new BoolQuery();

            var mustQuery = new List<QueryContainer>();
            var mustNotQuery = new List<QueryContainer>();
            var filterQuery = new List<QueryContainer>();
            if (model.StartDate != null)
            {
                filterQuery.Add(
                    new DateRangeQuery
                    {
                        GreaterThanOrEqualTo = model.StartDate,
                        LessThanOrEqualTo = model.EndDate.HasValue ? model.EndDate : DateTime.Now,
                        Field = "dateTime"
                    });
            }
            if (!string.IsNullOrWhiteSpace(model.Project))
            {
                //项目
                mustQuery.Add(new MatchQuery { Field = "projectName", Query = model.Project });
            }
            if (!string.IsNullOrWhiteSpace(model.RequestPath))
            {
                //请求地址
                mustQuery.Add(new MatchQuery { Field = "path", Query = model.RequestPath });
            }
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                //账户
                mustQuery.Add(new MatchQuery { Field = "userName", Query = model.UserName });
            }
            if (model.LogType.HasValue)
            {
                //筛选业务日志以及系统日志
                if (model.LogType == 1)
                {
                    filterQuery.Add(
                        new TermRangeQuery
                        {
                            Field = "eventId.id",
                            GreaterThanOrEqualTo = "1000"
                        });
                }
                else if (model.LogType == 2)
                {
                    filterQuery.Add(
                        new TermRangeQuery
                        {
                            Field = "eventId.id",
                            LessThan = "1000"
                        });
                }
            }
            if (!string.IsNullOrWhiteSpace(model.Keywords))
            {
                mustQuery.Add(
                    new MultiMatchQuery
                    {
                        Fields = new string[] { "message", "exceptionMessage" },
                        Query = model.Keywords
                    });
            }
            if (!string.IsNullOrWhiteSpace(model.Level))
            {
                //日志级别
                mustQuery.Add(new MatchQuery { Field = "level", Query = model.Level });
            }
            mustNotQuery.Add(new MatchQuery { Field = "path", Query = "/status" });

            boolQuery.Must = mustQuery;
            boolQuery.MustNot = mustNotQuery;
            boolQuery.Filter = filterQuery;
            searchRequest.Sort = new List<ISort> { new SortField { Field = "dateTime", Order = SortOrder.Descending } };
            searchRequest.From = model.PageIndex == 0 ? 0 : (model.PageIndex - 1) * model.PageSize;
            searchRequest.Size = model.PageSize;
            searchRequest.Query = boolQuery;
            var logList = _elasticClientFactory.Client.Search<LogResponse>(searchRequest);
            return Json(
                new QueryPageResponse<LogResponse>
                {
                    List = logList.Documents,
                    Total = logList.Total
                });
        }
    }
}