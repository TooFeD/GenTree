using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GenTree.Program.Controller
{
    class RequestController
    {
        public static async Task<string> HttpPOST(string url, string querystring, string contentType)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var body = querystring;
            request.Content = new StringContent(body);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var response = new HttpClient().SendAsync(request);
            var json = await response.Result.Content.ReadAsStringAsync();

            if (!response.Result.IsSuccessStatusCode)
            {
               // throw new WebException(response.Result.StatusCode, json);
            }
            return json;
        }
        public static async Task<string> HttpPOST(string url, Acces token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue(token.token_type, " " + token.access_token);
            var response = new HttpClient().SendAsync(request);
            var json = await response.Result.Content.ReadAsStringAsync();
            return json;
        }

        public static async Task<string> HttpGet(string url, Acces token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue(token.token_type," "+token.access_token);
            var response = new HttpClient().SendAsync(request);
            var json = await response.Result.Content.ReadAsStringAsync();
            return json;
        }
    }


    
}
