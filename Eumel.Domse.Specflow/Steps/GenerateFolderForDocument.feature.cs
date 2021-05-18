using System;
using Eumel.Domse.Core;
using Eumel.Domse.Specflow.Drivers;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace Eumel.Domse.Specflow.Steps
{
    [Binding]
    public class FolderStructureForDocumentsSteps
    {
        private readonly LocationGeneratorDriver _driver;

        public FolderStructureForDocumentsSteps()
        {
            _driver = new LocationGeneratorDriver();
        }

        [Given(@"a guid folder creator")]
        public void GivenAGuidFolderCreator()
        {
            _driver.Generator = new GuidLocationGenerator();
        }

        [Given(@"a document id of ""(.*)""")]
        public void GivenADocumentIdOf(Guid id)
        {
            _driver.Id = id;
        }

        [Given(@"a tree-based folder creator")]
        public void GivenATree_BasedFolderCreator()
        {
            _driver.Generator = new TreeBasedGenerator(null, null);
        }

        [Given(@"a metadata ""(.*)"" with value ""(.*)""")]
        public void GivenAMetadataWithValue(string key, string value)
        {
            _driver.Property[key] = value;
        }

        [Given(@"with configuration (.*)")]
        public void GivenAConfiguration(string jsonConfig)
        {
            var prototype = new { Property = "", Separator = "" };
            var cfg = JsonConvert.DeserializeAnonymousType(jsonConfig, prototype);
            _driver.Generator = new TreeBasedGenerator(cfg.Separator, cfg.Property);
        }

        [When(@"the folder name is generated")]
        public void WhenTheFolderNameIsGenerated()
        {
            _driver.GenerateFolder();
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBeMailInvoice(string expected)
        {
            _driver.GeneratedFolder.Should().Be(expected);
        }
    }
}
