using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AppGameLoans.Utilities.Util;


namespace AppGameLoans.Utilities.Extension
{
    public static class AuthorizationAndSwaggerExtension
    {
        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var flow = configuration.GetKey("Authentication:Flow");
            var scope = configuration.GetKey("Authentication:Scope");
            var url = configuration.GetKey("Authentication:AuthorizationUrl");
            var tokenUrl = configuration.GetKey("Authentication:TokenUrl");

            services
                .AddAuthorization()
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = configuration.GetKey("Authentication:Authority");
                    options.ApiName = configuration.GetKey("Authentication:Scope");
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("version1", new OpenApiInfo { Title = "App Game Loans - GameLoans - API", Version = "version1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                if (!string.IsNullOrEmpty(flow))
                {
                    if (!string.IsNullOrEmpty(flow) && flow.ToLower() == "apikey")
                    {
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = "Insira o token JWT com o texto 'Bearer ' antes",
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey
                        });

                        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] { }
                            }
                        });
                    }
                    else
                    {
                        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.OAuth2,
                            Scheme = "Bearer",
                            In = ParameterLocation.Header,
                            Flows = new OpenApiOAuthFlows()
                            {
                                Implicit = new OpenApiOAuthFlow
                                {
                                    AuthorizationUrl = new Uri(url),
                                    TokenUrl = new Uri(tokenUrl),
                                    Scopes = new Dictionary<string, string>
                                    {
                                        { scope, scope }
                                    }
                                }
                            }
                        });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" },
                                },
                                new[] { "apiVersion1" }
                            }
                        });
                    }
                }
            });
        }
    }
}
