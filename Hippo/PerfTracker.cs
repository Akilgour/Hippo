using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Hippo
{
    public class PerfTracker
    {
        private readonly Stopwatch _sw;
        private readonly HippoLogDetail _hippoLogDetail;

        public PerfTracker(HippoLogDetail hippoLogDetail)
        {
            _sw = Stopwatch.StartNew();
            _hippoLogDetail = hippoLogDetail;

            var beginTime = DateTime.Now;
            if (_hippoLogDetail.AdditionalInfo == null)
            {
                _hippoLogDetail.AdditionalInfo = new Dictionary<string, object>()
                {
                    { "Started", beginTime.ToString(CultureInfo.InvariantCulture) }
                };
            }
            else
            {
                _hippoLogDetail.AdditionalInfo.Add("Started", beginTime.ToString(CultureInfo.InvariantCulture));
            }
        }

        public PerfTracker(string name, string userId, string userName, string location, string product, string layer)
        {
            _hippoLogDetail = new HippoLogDetail()
            {
                Message = name,
                UserId = userId,
                UserName = userName,
                Product = product,
                Layer = layer,
                Location = location,
                Hostname = Environment.MachineName
            };

            var beginTime = DateTime.Now;
            _hippoLogDetail.AdditionalInfo = new Dictionary<string, object>()
            {
                { "Started", beginTime.ToString(CultureInfo.InvariantCulture)  }
            };
        }

        public PerfTracker(string name, string userId, string userName, string location, string product, string layer, Dictionary<string, object> perfParams)
            : this(name, userId, userName, location, product, layer)
        {
            foreach (var item in perfParams)
            {
                _hippoLogDetail.AdditionalInfo.Add("input-" + item.Key, item.Value);
            }
        }

        public void Stop()
        {
            _sw.Stop();
            _hippoLogDetail.ElapsedMilliseconds = _sw.ElapsedMilliseconds;
            HippoLogger.WritePerf(_hippoLogDetail);
        }
    }
}