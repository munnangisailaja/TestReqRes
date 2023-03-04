
using System;
using TechTalk.SpecFlow;
using TestDemoReqRes.apirefs;
using NUnit.Framework;
using Newtonsoft.Json;

namespace TestDemoReqRes.stepdefs
{
    [Binding]
    class UserDetailsStepDefs
    {        
        private static string response = "";

        [Given(@"the user have the api details")]
        public void GivenTheUserHaveTheApiDetails()
        {
            Console.WriteLine("Getting started with testing the API's");
        }

        [When(@"the user sends a ""(.*)"" request to ""(.*)""")]
        public void WhenTheUserSendsAGETRequestToListOfUsers(string method,string apiName)
        {           
            response = UserDetailsAPI.UserDetailsApi(method, apiName);
            ScenarioContext.Current["response"] = response;
        }

        [Given(@"the user user sends ""(.*)"" and ""(.*)"" details in the request")]
        public void WhenTheUserUserSendsAndDetailsInTheRequest(string name, string job)
        {
            ScenarioContext.Current["actualname"] = name;
            ScenarioContext.Current["actualjob"] = job;
        }


        [Then(@"the api should return http status code (.*)")]
        public void ThenTheApiShouldReturnHttpStatusCode(int status_code)
        {
            string stat_code = ScenarioContext.Current["StatusCode"].ToString();
            Assert.AreEqual(status_code.ToString(), stat_code, "Expected status code is " + stat_code + " but actual status code is " + stat_code);
        }

        [Then(@"the user details displayed in the response")]
        public void ThenTheUserDetailsDisplayedInTheResponse()
        {
            string response = ScenarioContext.Current["response"].ToString();

            var obj = JsonConvert.DeserializeObject<dynamic>(response);
            Console.WriteLine(obj.ToStringDictionary());
        }
        [Then(@"verify that the response contains ""(.*)"" and ""(.*)""")]
        [Then(@"verify that the response contain ""(.*)"" and ""(.*)""")]
        public void ThenVerifyThatTheResponseContainLindsayAndFerguson(string first_name, string last_name)
        {
            string response = ScenarioContext.Current["response"].ToString();

            Assert.That(response.Contains(first_name), first_name + " is not in the response " + response);
            Assert.That(response.Contains(last_name), last_name + " is not in the response " + response);
        }
    }
}
