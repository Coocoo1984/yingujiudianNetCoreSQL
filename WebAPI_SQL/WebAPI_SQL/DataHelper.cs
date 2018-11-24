using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class DataHelper
    {
        public static string DefualtDateTimeString = "yyyy-MM-dd HH:mm:ss";

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
                result = Convert.ToDateTime(dateTime.ToString(stringDateFormatString));//没得意义 DateTime.Value是long 只能在字符串ToStrin带参数转换 因为操作系统日期格式不一样
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
