using System;
using System.Text;

namespace Hippologamus.Server.Profiles.Shared
{
    public class ElapsedMillisecondsDisplay
    {
        public static string Resolve(int milliseconds)
        {
            bool started = false;
            var span = TimeSpan.FromMilliseconds(double.Parse(milliseconds.ToString()));
            var sb = new StringBuilder();

            if (span.Duration().Days > 0)
            {
                started = true;
                sb.Append($"{span.Days} day ");
            }

            if ((span.Duration().Hours > 0) || (started))
            {
                started = true;
                sb.Append($"{span.Hours} hour ");
            }

            if ((span.Duration().Minutes > 0) || (started))
            {
                sb.Append($"{span.Minutes} min ");
            }

            sb.Append($"{span.Seconds} sec { span.Milliseconds} ms");
            return sb.ToString();
        }
    }
}