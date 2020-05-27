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
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonDictionary = JsonConvert.DeserializeObject<IDictionary<string, string>>(jsonString);
            var resultList = jsonDictionary.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value));
            var result = string.Join("&", resultList);
            return result;
        }
    }
}