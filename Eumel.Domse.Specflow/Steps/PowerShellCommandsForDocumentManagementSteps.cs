using System;
using System.Linq;
using Eumel.Domse.Core;
using Eumel.Domse.PowerShell;
using Eumel.Domse.Specflow.Drivers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Eumel.Domse.Specflow.Steps
{
    [Binding]
    public class PowerShellCommandsForDocumentManagementSteps
    {
        private readonly PowershellCmdletDriver _driver;

        public PowerShellCommandsForDocumentManagementSteps()
        {
            _driver = new PowershellCmdletDriver();
        }

        [Given(@"a powershell parameter '(.*)':'(.*)'")]
        public void GivenAPowershellParameter(string key, string value)
        {
            _driver.AddParameter(key, value);
        }


        [When(@"execute Add-DomseDocument")]
        public void WhenExecuteAdd_DomseDocument()
        {
            _driver.Cmdlet = new GetDomseDocumentCmdlet();
            _driver.Execute();
        }

        [Then(@"the result should return a DocumentInformation")]
        public void ThenTheResultShouldReturnADocumentInformation()
        {
            _driver.Result.OfType<DocumentInformation>().Should().HaveCount(x => x > 0);
        }

        [Then(@"the DocumentInformation should contain the document name")]
        public void ThenTheDocumentInformationShouldContainTheDocumentName()
        {
        }
    }
}
