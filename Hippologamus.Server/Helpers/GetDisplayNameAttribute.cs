using System.ComponentModel;
using System.Linq;

namespace Hippologamus.Server.Helpers
{
    public class GetDisplayNameAttribute
    {
        public static string Value(object item, string name)
        {
            var property = item.GetType().GetProperty(name);
            var displayNameAttribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
            if (displayNameAttribute == null)
            {
                return name;
            }
            return displayNameAttribute.DisplayName;
        }
    }
}