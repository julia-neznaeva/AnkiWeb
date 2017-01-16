using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AnkiWeb
{
    class Program
    {
        static void Main(string[] args)
        {

            CookieContainer cookieJar = new CookieContainer();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ankiweb.net");
            httpWebRequest.CookieContainer = cookieJar;
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            int cookieCount = cookieJar.Count;
            string postData = "submited = 1";
            postData += "&username = sequel282@gmail.com";
            postData += "&password = 1123581321";
            postData += "&csrf_token = eyJpcCI6ICIxODguMTYzLjE4NC4xNjYiLCAiaWF0IjogMTQ4NDYwMDc4NiwgIm9wIjogImxvZ2luIn0";
            var data = Encoding.ASCII.GetBytes(postData);
            HttpWebRequest loginRequest  = (HttpWebRequest)WebRequest.Create("https://ankiweb.net/account/login");
            loginRequest.Method = "POST";
            loginRequest.ContentLength = data.Length;

            using (var stream = loginRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)loginRequest.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();



        }
    }
}
