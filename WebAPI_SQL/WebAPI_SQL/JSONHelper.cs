using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class JSONHelper
    {

        public static string DataTable2JSONString(DataTable dt)
        {
            string reslut = string.Empty;
            try
            {
                reslut = JsonConvert.SerializeObject(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return reslut;
        }

    }
}
