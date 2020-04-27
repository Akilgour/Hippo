using Hippo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Demo.API
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
            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(new TrackPerformanceFilter("Demo", "API")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(eApp =>
            {
                eApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorCtx = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorCtx != null)
                    {
                        var ex = errorCtx.Error;
                        WebHelper.LogWebError("Demo", "API", ex, context);

                        var errorId = Activity.Current?.Id ?? context.TraceIdentifier;
                        var jsonResponse = JsonConvert.SerializeObject(new CustomErrorResponse
                        {
                            ErrorId = errorId,
                            Message = "Some kind of error happened in the API."
                        });
                        await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
                    }
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}