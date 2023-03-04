using RestSharp;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using Newtonsoft.Json;

namespace TestDemoReqRes.apirefs
{
    class UserDetailsAPI
    {
        private static string url = ConfigurationManager.AppSettings["BaseUrl"];        


        public static string UserDetailsApi(string method, string apiname)
        {
            string apiUrl = ConfigurationManager.AppSettings[apiname];
            Console.WriteLine("Url... "+ url + apiUrl);
            string api_url = url + apiUrl;
            
            var client = new RestClient();
            var request = new RestRequest();
            if (method.Equals("GET"))
            {
                request = new RestRequest(api_url, Method.Get);
            }
            else
            {
                if (method.Equals("POST"))
                {
                    request = new RestRequest(api_url, Method.Post);
                }
                else if (method.Equals("PUT"))
                {
                    request = new RestRequest(api_url, Method.Put);
                }
                else if (method.Equals("PATCH"))
                {
                    request = new RestRequest(api_url, Method.Patch);
                }
                request.AddHeader("Content-Type", "application/json");

                userDetails userdet = new userDetails();
                userdet.name = ScenarioContext.Current["actualname"].ToString();
                userdet.job = ScenarioContext.Current["actualjob"].ToString();
                string jsonString = JsonConvert.SerializeObject(userdet);
                Console.WriteLine("Actual request bodu... "+jsonString);
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            }
            Console.WriteLine("request sending... "+request);
            RestResponse response = client.Execute(request);
            ScenarioContext.Current["StatusCode"] = (int)response.StatusCode;
            return response.Content;
        }       
    }    

    class userDetails
    {
        public string name { get; set; }
        public string job { get; set; }        
    }
}
