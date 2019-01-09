//*******************************
// Create By Wwb
// Date 2018-11-07 13:42
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SmartSql.Abstractions;
using SmartSql.DyRepository;
using Spark.Config.Api.Entity;
using Spark.Core.Values;

namespace Spark.Config.Api.Repository
{
    public interface IMsAppRepository : IRepository<MsApp, int>
    {
        QueryByPageResponse<MsApp>
            QueryPaged(object reqParams);
    }
}