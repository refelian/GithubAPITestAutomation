using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace GitHubAPITestAutomation.Tests
{
    [TestFixture]
    public class CreateRepoTest : BaseClass
    {
        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        public string URL = "https://api.github.com/user/repos";
        public string URLRepos = "https://api.github.com/repos/";
        public string Username = "ThisIsATestUser838";
        //fill in your username/password and push to my public repo ;-V 
        public string RightPassword = "TheRightPassword";
        public string WrongPassword = "wrongpassword";
        public string repoName = "Hello-World";


        [Test]
        public void CreateRepoEmptyAuth()
        {
            var client = new RestClient(URL);
            var request = new RestRequest(Method.POST);
            
            // Wanted to do something quickly with Jschema to parse and check the response but well: time...
            // JSchema schema = JSchema.Parse(@"{
            //     'type': 'object',
            //     'properties': {
            //         'message': {'type':'string'},
            //         'documentation_url': {'type': 'string'}
            //             }
            //             }");

            IRestResponse response = client.Execute(request);

            string requestResponse = response.Content;
            var requestResponseJson = JsonConvert.SerializeObject(requestResponse);
            

            Console.WriteLine(requestResponseJson);
            TestContext.Out.WriteLine(requestResponseJson);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public void CreateRepo()
        {
            var client = new RestClient(URL);
            var requestCreate = new RestRequest(Method.POST);
            
            client.Authenticator = new HttpBasicAuthenticator(Username, RightPassword);
            requestCreate.AddJsonBody(new { name = repoName });
            
            IRestResponse responseCreate = client.Execute(requestCreate);
            Assert.AreEqual(HttpStatusCode.Created, responseCreate.StatusCode);

        }

        [Test]
        public void DeleteRepo()
        {
            var client = new RestClient(URLRepos+Username+"/"+repoName);
            var requestDelete = new RestRequest(Method.DELETE);
            
            client.Authenticator = new HttpBasicAuthenticator(Username, RightPassword);
            
            IRestResponse responseDelete = client.Execute(requestDelete);
            Assert.AreEqual(HttpStatusCode.NoContent, responseDelete.StatusCode);

        }
    }
}
