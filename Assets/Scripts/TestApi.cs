using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;


namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = "";
            string secret = "";

            var client = new RestClient("https://xxx.xxx.com/services/api/oauth2/token");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&scope=all&client_id=" + id + "&client_secret=" + secret, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            dynamic resp = JObject.Parse(response.Content); 
            string token = resp.access_token;            

            client = new RestClient("https://xxx.xxx.com/services/api/x/users/v1/employees");
            request = new RestRequest(Method.Get.ToString());
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            response = client.Execute(request);
        }        
    }
}
