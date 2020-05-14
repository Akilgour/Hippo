using Hippo.Serilog.Builders;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hippo.Serilog
{
    public static class SerilogHelpers
    {
        /// <summary>
        /// Provides standardized, centralized Serilog wire-up for a suite of applications.
        /// </summary>
        /// <param name="loggerConfig">Provide this value from the UseSerilog method param</param>
        /// <param name="provider">Provide this value from the UseSerilog method param as well</param>
        /// <param name="applicationName">Represents the name of YOUR APPLICATION and will be used to segregate your app
        /// from others in the logging sink(s).</param>
        /// <param name="config">IConfiguration settings -- generally read this from appsettings.json</param>
        public static void WithSimpleConfiguration(this LoggerConfiguration loggerConfig,
            IServiceProvider provider, string applicationName, IConfiguration config)
        {
            var name = Assembly.GetEntryAssembly().GetName();

            loggerConfig
                .ReadFrom.Configuration(config) // minimum levels defined per project in json files
                .Enrich.WithAspnetcoreHttpcontext(provider, AddCustomContextDetails)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", $"{name.Name}")
                .Enrich.WithProperty("Version", $"{name.Version}")
            //.WriteTo.File(new CompactJsonFormatter(),
            //    $@"C:\temp\Logs\{applicationName}.json");

            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.WithProperty("ElapsedMilliseconds"))
                .Filter.ByIncludingOnly(Matching.WithProperty("PerfItem"))
                .WriteTo.MSSqlServer(
                    connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Logging;Trusted_Connection=True;",
                    tableName: "PerfLogs",
                    autoCreateSqlTable: true,
                    columnOptions: SqlPerfColumnOptions.Create()))

            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.WithProperty("UsageName"))
                .WriteTo.MSSqlServer(
                    connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Logging;Trusted_Connection=True;",
                    tableName: "UsageLogs",
                    autoCreateSqlTable: true,
                    columnOptions: SqlUsageColumnOptions.Create()))

            .WriteTo.Logger(lc => lc
                 .Filter.ByExcluding(Matching.WithProperty("ElapsedMilliseconds"))
                 .Filter.ByExcluding(Matching.WithProperty("UsageName"))
                 .WriteTo.MSSqlServer(
                    connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Logging;Trusted_Connection=True;",
                    tableName: "DetailLogs",
                    autoCreateSqlTable: true,
                    columnOptions: SqlDetailColumnOptions.Create()));
        }

        private static UserInfo AddCustomContextDetails(IHttpContextAccessor ctx)
        {
            var excluded = new List<string> { "nbf", "exp", "auth_time", "amr", "sub" };
            const string userIdClaimType = "sub";

            var context = ctx.HttpContext;
            var user = context?.User.Identity;
            if (user == null || !user.IsAuthenticated) return null;

            var userId = context.User.Claims.FirstOrDefault(a => a.Type == userIdClaimType)?.Value;
            var userInfo = new UserInfo
            {
                UserName = user.Name,
                UserId = userId,
                UserClaims = new Dictionary<string, List<string>>()
            };
            foreach (var distinctClaimType in context.User.Claims
                .Where(a => excluded.All(ex => ex != a.Type))
                .Select(a => a.Type)
                .Distinct())
            {
                userInfo.UserClaims[distinctClaimType] = context.User.Claims
                    .Where(a => a.Type == distinctClaimType)
                    .Select(c => c.Value)
                    .ToList();
            }

            return userInfo;
        }
    }
}