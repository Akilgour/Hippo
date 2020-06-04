using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hippologamus.Server.Services.Interface;
using Hippologamus.Server.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Hippologamus.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            //Make HttpContext be usable anywhere in code, this allows the getting of users details
            //Just inject IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Addeds cookie authentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
            options =>
            {
                options.Authority = "https://localhost:44333";
                options.ClientId = "hippologamus";
                options.ClientSecret = "108B7B4F-BEFC-4DD2-82E1-7F025F0F75D0";
                options.ResponseType = "code id_token";
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("hippologamusapi");
                    //options.CallbackPath = ...
                    options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

            });

            services.AddHttpClient<IPerfLogAssemblyService, PerfLogAssemblyService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });

            services.AddHttpClient<IPerfLogPerfItemService, PerfLogPerfItemService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });

            services.AddHttpClient<IPerfLogDisplayService, PerfLogDisplayService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });

            services.AddHttpClient<IErrorLogService, ErrorLogService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });


            //Adds Automapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
