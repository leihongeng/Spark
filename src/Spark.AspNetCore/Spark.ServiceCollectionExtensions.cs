using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Spark.AspNetCore.Authentication;
using Spark.Core;
using System;
using System.Text;

namespace Spark.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpark(this IServiceCollection services, Action<SparkBuilder> setupAction)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, HttpContextUser>();
            services.AddSingleton<IRequestScopedDataRepository, HttpDataRepository>();
            services.AddSingleton<IErrorCode, EmptyErrorCode>();

            //注册通用中间件
            services.AddSingleton<IStartupFilter, StartupFilter>();

            var builder = new SparkBuilder(services);
            setupAction?.Invoke(builder);

            return services;
        }

        /// <summary>
        /// Bucket授权认证
        /// </summary>
        public static SparkBuilder AddAuthentication(this SparkBuilder builder, IConfiguration configuration, string key = "GlobalConfig:Audience")
        {
            AuthenticationOptions config = new AuthenticationOptions();
            configuration.GetSection(key).Bind(config);
            var keyByteArray = Encoding.ASCII.GetBytes(config.Secret);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = config.Issuer,//发行人
                ValidateAudience = true,
                ValidAudience = config.Audience,//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };
            builder.Services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                //不使用https
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = tokenValidationParameters;
            });
            return builder;
        }

        /// <summary>
        /// Bucket授权认证
        /// </summary>
        public static SparkBuilder AddAuthentication(this SparkBuilder builder, Action<AuthenticationOptions> configAction)
        {
            if (configAction == null) throw new ArgumentNullException(nameof(configAction));

            var config = new AuthenticationOptions();
            configAction?.Invoke(config);

            var keyByteArray = Encoding.ASCII.GetBytes(config.Secret);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = config.Issuer,//发行人
                ValidateAudience = true,
                ValidAudience = config.Audience,//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };
            builder.Services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                //不使用https
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = tokenValidationParameters;
            });

            return builder;
        }

        public static SparkBuilder AddJwtHandler(this SparkBuilder builder, IConfiguration configuration, string key = "GlobalConfig:Audience")
        {
            builder.Services.Configure<AuthenticationOptions>(configuration.GetSection(key));
            builder.Services.AddSingleton<IJwtHandler, JwtHandler>();
            return builder;
        }

        public static SparkBuilder AddJwtHandler(this SparkBuilder builder, Action action)
        {
            action();
            builder.Services.AddSingleton<IJwtHandler, JwtHandler>();
            return builder;
        }
    }
}