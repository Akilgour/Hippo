using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Hippo.Serilog.Filters;
using Hippo.Serilog.Middleware;
using Hippologamus.Data.Context;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

//For comments in Swagger
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Hippologamus.API
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
            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    Hippologamus.DTO.Policies.CanViewErrorLogs,
                    Hippologamus.DTO.Policies.CanViewErrorLogsPolicy());
            });


            //This makes sure all users are authorised when calling controllers
            var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();

            services.AddControllers(configure =>
            {
                configure.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy));
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = "https://localhost:44333/";
                  options.ApiName = "hippologamusapi";
              });


            services.AddDbContext<HippologamusContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("HippologamusContext"))
           .EnableSensitiveDataLogging());

            //This add the Hippo Performance Tracker
            services.AddMvc(options =>
             {

                 //To track Performance with HIPPO
                 options.Filters.Add(new TrackPerformanceFilter());
             });

            //Added Swagger
            services.AddSwaggerGen(setUpAction =>
            {
                setUpAction.SwaggerDoc("HippologamusAPI", new OpenApiInfo { Title = "Hippologamus API", Version = "1" });

                //Add comments, to get this to work you need to go into project properties, build tab, then select "XML Documentation file"
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                setUpAction.IncludeXmlComments(xmlCommentFullPath);
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.

            builder.RegisterModule(new Autofac.AutofacConfiguration());
            builder.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            //This add HIPPO exeption handling
            app.UseApiExceptionHandler();

            //Added Swagger
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/HippologamusAPI/swagger.json", "Hippologamus API");
                });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}