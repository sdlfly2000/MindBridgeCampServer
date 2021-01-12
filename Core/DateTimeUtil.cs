using System;

namespace Core
{
    public class DateTimeUtil
    {
        public static DateTime GetNow()
        {
            var now = DateTime.Now.AddHours(8);

            return DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second));
        }
    }
}
