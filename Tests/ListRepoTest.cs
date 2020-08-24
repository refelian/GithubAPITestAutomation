using NUnit.Framework;
using RestSharp;
using System.Net;

namespace GitHubAPITestAutomation.Tests
{
    [TestFixture]
    public class ListRepoTest : BaseClass
    {
        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        public string URL = "https://api.github.com/orgs/dotnet/repos";
        public string Username = "ThisIsATestUser838";
        //fill in your username/password and push to my public repo ;-V 
        public string RightPassword = "TheRightPassword";
        public string WrongPassword = "wrongpassword";
        
            [Test]
            public void GetPublicRepoList()
             {
                var client = new RestClient(URL);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                //If I would have more time I would create a class where I would serialize the JsonProperties. 
                Assert.NotNull(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
             }
    
    }
}
