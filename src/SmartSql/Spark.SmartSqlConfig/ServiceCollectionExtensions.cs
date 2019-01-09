using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartSql;
using System;
using System.Collections.Generic;
using System.Text;
using Spark.AspNetCore;
using Spark.SmartSqlConfig;

namespace Spark.SmartSqlConfig
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加SmartSql支持。从配置中心读取配置
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configurationSection"></param>
        /// <param name="repositoryAssembly">仓库程序集名</param>
        /// <returns></returns>
        public static SparkBuilder AddSmartSql(this SparkBuilder builder, IConfigurationSection configurationSection, params string[] repositoryAssembly)
        {
            builder.Services.Configure<SmartSqlDbConfigOptions>(configurationSection);
            builder.Services.AddSmartSql(sp => new SmartSqlOptions().UseOptions(sp));

            builder.Services.AddRepositoryFactory();
            foreach (var para in repositoryAssembly)
            {
                builder.Services.AddRepositoryFromAssembly((options) =>
                {
                    options.AssemblyString = para;
                });
            }

            return builder;
        }

        public static SparkBuilder AddSmartSql(this SparkBuilder builder, params string[] repositoryAssembly)
        {
            builder.Services.AddSmartSql();

            builder.Services.AddRepositoryFactory();
            foreach (var para in repositoryAssembly)
            {
                builder.Services.AddRepositoryFromAssembly((options) =>
                {
                    options.AssemblyString = para;
                });
            }

            return builder;
        }
    }
}