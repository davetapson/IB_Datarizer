using IB_DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_Datarizer
{
    public static class DataUtils
    {
        public static List<RequestSymbol> GetRequestSymbols()
        {
            RequestSymbolRepository requestSymbol_Repository = new RequestSymbolRepository();
            return requestSymbol_Repository.RequestSymbols;
        }

        public static DateTime ReturnUTCDateTimeForUTCUnixEpochTime(long unixEpocTime)
        {
            DateTimeOffset utcDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixEpocTime);
            DateTime utcTime = utcDateTimeOffset.DateTime;

            return utcTime;
        }

        public static DateTime ReturnESTDateTimeForUTCDateTime(DateTime utcDateTime)
        {
            DateTime easternTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcDateTime, "Utc", "Eastern Standard Time");

            return easternTime;
        }
    }
}
