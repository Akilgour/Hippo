using System;

namespace Hippologamus.Server.Profiles.Shared
{
    public class DateTimeDisplay
    {
        public static string Resolve(DateTime source) => string.Format("{0:dd/MM/yyyy HH:mm}", source.ToLocalTime());
    }
}
