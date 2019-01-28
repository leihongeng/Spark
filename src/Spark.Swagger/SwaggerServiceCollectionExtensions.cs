using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Spark.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Spark.Swagger
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static SparkBuilder AddSwagger(this SparkBuilder builder, Action<Dictionary<string, Info>> swaggerDocAction, string swaggerXmlName)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                var swaggerDoc = new Dictionary<string, Info>();
                swaggerDocAction?.Invoke(swaggerDoc);
                foreach (var dic in swaggerDoc)
                {
                    options.SwaggerDoc(dic.Key, dic.Value);
                }

                //根据ApiExplorerSettingsAttribute 对接口进行分组
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiExplorerSettingsAttribute>()
                        .Select(attr => attr.GroupName);
                    if (docName.ToLower() == "v1" && versions.FirstOrDefault() == null)
                    {
                        return true;
                    }
                    return versions.Any(v => v.ToString() == docName);
                });
                options.CustomSchemaIds((type) => type.FullName);
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{swaggerXmlName}.xml");
                if (File.Exists(filePath))
                {
                    options.IncludeXmlComments(filePath);
                }
                //开启swagger认证
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "请输入带有Bearer的Token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                });
                //Json Token认证方式，此方式为全局添加
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
                options.OperationFilter<SwaggerFileUploadFilter>();
            });

            return builder;
        }
    }
}