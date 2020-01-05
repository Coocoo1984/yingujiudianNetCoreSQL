using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class MessageHelper
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static readonly string MessageUri = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";//消息推送地址带参
        public static readonly string GetTockenUri = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=ww3589f3907e9ad0e5&corpsecret=zVNtrajjOJgi0C7PC7Xzw7mpvJI3340j-LZhsE9bx2s";//

        public class TextMesage : StringContent
        {
            public TextMesage(object obj) :
                        base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }

        public class token
        {
            public int errcode { get; set; }
            public string errmsg { get; set; }
            public string access_token { get; set; }
            public int expires_in { get; set; }
        }

        public static async void Post(string touser, string title, string time, string content)
        {
            //var httpClient = HttpClientFactory().CreateClient();// ServiceBase.IHttpClientFactory.CreateClient();
            //取token(目前达不到24小时2000次的限制 不判断token失效操作)

            var response = httpClient.GetAsync(GetTockenUri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(result);
            token jsonObj = (token)serializer.Deserialize(new JsonTextReader(sr), typeof(token));
            if (jsonObj.errcode == 0)
            {
                string strAccessToken = jsonObj.access_token;

                HttpContent contentObj = new TextMesage(new
                {
                    touser = touser,
                    msgtype = "textcard",
                    agentid = "1000008",
                    textcard = new
                    {
                        title = title,
                        description = "<div class=\"gray\">" + time + "</div> <div class=\"normal\">" + content + "</div>",
                        url = "http://wxadmin.changan-hotel.cn",
                        btntxt = "",
                    }
                });
                await httpClient.PostAsync(MessageUri + strAccessToken, contentObj);
            }
        }
    }
}
