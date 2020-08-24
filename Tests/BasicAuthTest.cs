using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace GitHubAPITestAutomation.Tests
{
    [TestFixture]
    public class BasicAuthTest : BaseClass
    {
        [SetUp]
        public override void TestInitialize() => base.TestInitialize();

        public string URL = "https://api.github.com/user";
        public string Username = "ThisIsATestUser838";
        //fill in your username/password and push to my public repo ;-V 
        public string RightPassword = "TheRightPassword";
        public string WrongPassword = "wrongpassword";

        
            [Test]
            public void TestRespOk()
             {
                var client = new RestClient(URL);
                var request = new RestRequest(Method.GET);

                client.Authenticator = new HttpBasicAuthenticator(Username, RightPassword);
                IRestResponse response = client.Execute(request);
           
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
             }

             [Test]
            public void TestRespPassNOk()
             {
                var client = new RestClient(URL);
                var request = new RestRequest(Method.GET);

                client.Authenticator = new HttpBasicAuthenticator(Username, WrongPassword);
                IRestResponse response = client.Execute(request);
            
                Assert.IsNotNull(HttpResponseHeader.WwwAuthenticate);
                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
             }
    }
}
