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

     
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ankiweb.net");
            httpWebRequest.CookieContainer = new CookieContainer();

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

           
            string postData = "submited = 1";
            postData += "&username = sequel282@gmail.com";
            postData += "&password = 1123581321";
            var data = Encoding.ASCII.GetBytes(postData);
            HttpWebRequest loginRequest  = (HttpWebRequest)WebRequest.Create("https://ankiweb.net/account/login");
            loginRequest.Method = "POST";
            loginRequest.ContentType = "application/x-www-form-urlencoded";
            loginRequest.ContentLength = data.Length;
            loginRequest.CookieContainer = httpWebRequest.CookieContainer;

            using (var stream = loginRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)loginRequest.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();



        }
    }
}
