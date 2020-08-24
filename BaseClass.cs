using RestSharp;
using RestSharp.Authenticators;

namespace GitHubAPITestAutomation
{
    public abstract class BaseClass
    {
        public virtual void TestInitialize()
        {
            //Empty for now, could be used in case of test inheritance tree
        }
        
        public void SomeCommonVoid()
        {
            //TBD
        }
    }
}
