using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace Hippo
{
    public class WebHelper
    {
        public static void LogWebUsage(string product, string layer, string activityName,
              HttpContext context, Dictionary<string, object> additionalInfo = null)
        {
            var details = GetWebFlogDetail(product, layer, activityName, context, additionalInfo);
            HippoLogger.WriteUsage(details);
        }

        public static void LogWebDiagnostic(string product, string layer, string message,
            HttpContext context, Dictionary<string, object> diagnosticInfo = null)
        {
            var details = GetWebFlogDetail(product, layer, message, context, diagnosticInfo);
            HippoLogger.WriteDiagnostic(details);
        }

        public static void LogWebError(string product, string layer, Exception ex,
            HttpContext context)
        {
            var details = GetWebFlogDetail(product, layer, null, context, null);
            details.Exception = ex;

            HippoLogger.WriteError(details);
        }

        public static HippoLogDetail GetWebFlogDetail(string product, string layer,
            string activityName, HttpContext context,
            Dictionary<string, object> additionalInfo = null)
        {
            var detail = new HippoLogDetail
            {
                Product = product,
                Layer = layer,
                Message = activityName,
                Hostname = Environment.MachineName,
                CorrelationId = Activity.Current?.Id ?? context.TraceIdentifier,
                AdditionalInfo = additionalInfo ?? new Dictionary<string, object>()
            };

            GetUserData(detail, context);
            GetRequestData(detail, context);
            // Session data??
            // Cookie data??

            return detail;
        }

        private static void GetRequestData(HippoLogDetail hippoLogDetail, HttpContext context)
        {
            var request = context.Request;
            if (request != null)
            {
                hippoLogDetail.Location = request.Path;

                hippoLogDetail.AdditionalInfo.Add("UserAgent", request.Headers["User-Agent"]);
                // non en-US preferences here??
                hippoLogDetail.AdditionalInfo.Add("Languages", request.Headers["Accept-Language"]);

                var qdict = Microsoft.AspNetCore.WebUtilities
                    .QueryHelpers.ParseQuery(request.QueryString.ToString());
                foreach (var key in qdict.Keys)
                {
                    hippoLogDetail.AdditionalInfo.Add($"QueryString-{key}", qdict[key]);
                }
            }
        }

        private static void GetUserData(HippoLogDetail hippoLogDetail, HttpContext context)
        {
            var userId = "";
            var userName = "";
            var user = context.User;  // ClaimsPrincipal.Current is not sufficient
            if (user != null)
            {
                var i = 1; // i included in dictionary key to ensure uniqueness
                foreach (var claim in user.Claims)
                {
                    if (claim.Type == ClaimTypes.NameIdentifier)
                        userId = claim.Value;
                    else if (claim.Type == "name")
                        userName = claim.Value;
                    else
                        // example dictionary key: UserClaim-4-role
                        hippoLogDetail.AdditionalInfo.Add($"UserClaim-{i++}-{claim.Type}", claim.Value);
                }
            }
            hippoLogDetail.UserId = userId;
            hippoLogDetail.UserName = userName;
        }
    }
}