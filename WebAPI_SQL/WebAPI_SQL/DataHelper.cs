using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class DataHelper
    {
        public static DateTime? GetDateTime(DateTime? dateTime)
        {
            DateTime? result = null;
            if (dateTime == null || dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue)
            {
                result = null;
            }
            else
            {
                result = dateTime;
            }
            return result;
        }

        public static DateTime? GetDateTime(DateTime dateTime)
        {
            DateTime? result = null;
            if (dateTime == null || dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue)
            {
                result = null;
            }
            else
            {
                result = dateTime;
            }
            return result;
        }

        public static DateTime? GetDateTime(DateTime dateTime, string stringDateFormatString)
        {
            DateTime? result = null;
            if (dateTime == null || dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue)
            {
                result = null;
            }
            else
            {
                result = Convert.ToDateTime(dateTime.ToString(stringDateFormatString));
            }
            return result;
        }

        public static List<int> GetListInt(string listIntString)
        {
            List<int> result = null;

            if (!string.IsNullOrWhiteSpace(listIntString))
            {
                string[] arr = listIntString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                result = Array.ConvertAll<string, int>(arr, s => int.Parse(s)).ToList();
            }

            return result;
        }
    }
}
