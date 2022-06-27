using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace _1124PictureService
{
    
    class TranService : Trans
    {
        TransMessage tmsg = new TransMessage();

        public string TransText(string msg)
        {
            //요청 기본 URL
            string url = "https://openapi.naver.com/v1/papago/n2mt";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "YZDFavX4R3J5A61Zay1a");
            request.Headers.Add("X-Naver-Client-Secret", "_K6KGFK56L");
            request.Method = "POST";
            string query = msg;


            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ko&target=en&text=" + query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            //응답(Response)
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();   //응답에 대한 결과물
            stream.Close();
            response.Close();
            reader.Close();

            JObject jobj = JObject.Parse(text);
            string message = jobj["message"]["result"]["translatedText"].ToString();
            tmsg.Transmsg = message;
            return message;
        }
    }
}
