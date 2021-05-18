using TechTalk.SpecFlow;

namespace Eumel.Domse.Specflow.Steps
{
    [Binding]
    public class PowerShellCommandsForDocumentManagementSteps
    {
        [Given(@"a powershell parameter ""(.*)"":""(.*)""")]
        public void GivenAPowershellParameter(string key, string value)
        {
            ScenarioContext.Current.Pending();
        }
        
        
        [When(@"execute Add-DomseDocument")]
        public void WhenExecuteAdd_DomseDocument()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should return a DocumentInformation")]
        public void ThenTheResultShouldReturnADocumentInformation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the DocumentInformation should contain the document name")]
        public void ThenTheDocumentInformationShouldContainTheDocumentName()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
