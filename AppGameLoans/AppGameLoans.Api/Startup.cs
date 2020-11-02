using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppGameLoans.Utilities.Extension;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppGameLoans.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.ConfigureDbContext(Configuration);
            services.RepositoriesSettings();
            services.ServicesSettings();
            services.AddControllers();
            services.AddCors();

            services.ConfigureAuthorizationJwt(Configuration);

            services.AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers()
              .AddNewtonsoftJson(options =>
                  options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
               );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = (c) =>
                    {
                        var exception = c.Features.Get<IExceptionHandlerFeature>();
                        var statusCode = exception.Error.GetType().Name switch
                        {
                            "ArgumentException" => HttpStatusCode.BadRequest,
                            _ => HttpStatusCode.ServiceUnavailable
                        };

                        c.Response.StatusCode = (int)statusCode;
                        var content = Encoding.UTF8.GetBytes($"Erro : [{exception.Error.Message}]");
                        c.Response.Body.WriteAsync(content, 0, content.Length);

                        return Task.CompletedTask;
                    }
                });
                app.UseHsts();
            }
                          
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App Game Loans");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
