using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hippologamus.Server.Factorys
{
    public static class ObjectToURLString
    {
        //https://stackoverflow.com/questions/6848296/how-do-i-serialize-an-object-into-query-string-format

        public static string Create(object obj)
        {
            var step1 = JsonConvert.SerializeObject(obj);

            var step2 = JsonConvert.DeserializeObject<IDictionary<string, string>>(step1);

            var step3 = step2.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value));

            var result = string.Join("&", step3);
            return result;
        }
    }
}