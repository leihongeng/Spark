using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.AspNetCore
{
    public interface IOptionsExtension
    {
        void AddServices(IServiceCollection services);
    }
}