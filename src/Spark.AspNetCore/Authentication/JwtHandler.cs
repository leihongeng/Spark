using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Spark.Core;
using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Spark.AspNetCore.Authentication
{
    public class JwtHandler : IJwtHandler
    {
        private readonly AuthenticationOptions _options;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SecurityKey _securityKey;
        private readonly SigningCredentials _signingCredentials;

        public JwtHandler(IOptions<AuthenticationOptions> options)
        {
            _options = options.Value;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
            _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
        }

        public JsonWebToken Create(long uid, List<Claim> claims = null, string scope = null)
        {
            var exp = DateTime.Now.AddMinutes(_options.ExpiryMinutes);

            return Create(uid, exp, claims, scope);
        }

        public JsonWebToken Create(long uid, DateTime expiresTime, List<Claim> claims = null, string scope = null)
        {
            if (claims == null)
            {
                claims = new List<Claim>();
            }
            claims.Add(new Claim("Scope", scope ?? _options.Scope));
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(uid.ToString()));
            identity.AddClaims(claims);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                SigningCredentials = _signingCredentials,
                Subject = identity,
                Expires = expiresTime
            });

            return new JsonWebToken
            {
                access_token = token,
                expires_in = _options.ExpiryMinutes * 60
            };
        }
    }
}