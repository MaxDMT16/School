﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jose;
using Newtonsoft.Json.Linq;
using SchoolSystem.Abstractions.Authorization.Scopes;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Configuration;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Domain.Authorization.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private static readonly string ScopesHeaderName = "Scope";

        private readonly IAccessTokenConfiguration _configuration;

        public AccessTokenService(IAccessTokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken<TPayload>(TPayload payload, string key, ScopeFlag scope)
            where TPayload : Payload
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var extraHeaders = new Dictionary<string, object>
            {
                {ScopesHeaderName, scope}
            };

            payload.CreationDate = DateTime.UtcNow;
            payload.LifeTimeTicks = _configuration.LifeTime.Ticks;

            var concatenatedKey = _configuration.ServerKey + key;

            var keyBytes = Encoding.UTF8.GetBytes(concatenatedKey);

            var encode = JWT.Encode(payload, keyBytes, JwsAlgorithm.HS512, extraHeaders);

            return encode;
        }

        public void ValidateToken<TPayload>(string token, string key, ScopeFlag requiredScope)
            where TPayload : Payload
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            try
            {
                var concatenatedKey = _configuration.ServerKey + key;

                var keyBytes = Encoding.UTF8.GetBytes(concatenatedKey);

                var payload = JWT.Decode<TPayload>(token, keyBytes);


                ValidatePayload(payload);

                var headers = JWT.Headers<JObject>(token);

                ValidateScopes(requiredScope, headers);
            }
            catch (JoseException e)
            {
                throw new InvalidOperationException(); //InvalidAccessTokenException(e);
            }
            catch (SchoolSystemException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(); //AccessTokenDecodingException(e);
            }
        }

        private void ValidateScopes(ScopeFlag requiredScope, JObject headers)
        {
            var isScopesHeaderExist =
                headers.TryGetValue(ScopesHeaderName, StringComparison.OrdinalIgnoreCase, out var value);

            if (!isScopesHeaderExist)
            {
                throw new InvalidOperationException(); //AccessTokenWithoutScopesException(headersDictionary);
            }

            var scope = value.ToObject<ScopeFlag>();

            if (requiredScope > scope)
            {
                throw new InvalidOperationException(); //AccessTokenScopeMissException(tokenScopes);
            }
        }

        private void ValidatePayload<TPayload>(TPayload payload)
            where TPayload : Payload
        {
            if (payload.LifeTimeTicks != _configuration.LifeTime.Ticks)
            {
                throw
                    new InvalidOperationException(); //AccessTokenLifetimeMismatchException(payload.LifeTimeTicks, _configuration.Lifetime.Ticks);
            }

            var expirationDate = payload.CreationDate.AddTicks(payload.LifeTimeTicks);

            if (expirationDate < DateTime.UtcNow)
            {
                throw new InvalidOperationException(); //AccessTokenExpiredException(expireTime);
            }
        }

        public TPayload GetPayload<TPayload>(string token) where TPayload : Payload
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            try
            {
                return JWT.Payload<TPayload>(token);
            }
            catch (JoseException e)
            {
                throw new InvalidOperationException(); //InvalidAccessTokenException(e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(); //AccessTokenDecodingException(e);
            }
        }
    }
}