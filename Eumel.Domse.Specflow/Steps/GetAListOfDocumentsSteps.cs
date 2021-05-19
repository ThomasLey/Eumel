using System;
using System.IO;
using System.Reflection;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core;
using Eumel.Domse.Specflow.Drivers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Eumel.Domse.Specflow.Steps
{
    [Binding]
    public class GetAListOfDocumentsSteps
    {
        private readonly GetAListOfDocumentsDriver _driver;

        public GetAListOfDocumentsSteps()
        {
            _driver = new GetAListOfDocumentsDriver();
        }

        [Given(@"a storage location '(.*)'")]
        public void GivenAStorageLocation(string path)
        {
            var rootPath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName ?? string.Empty;
            _driver.StoragePath = Path.Combine(rootPath, path);
        }

        [Given(@"a file folder storage service is used")]
        public void GivenAFileFolderStorageServiceIsUsed()
        {
            _driver.StorageService = new FolderStorageService(_driver.StoragePath);
        }

        [When(@"a list of documents is requested")]
        public void WhenAListOfDocumentsIsRequested()
        {
            _driver.Documents = _driver.GetDocuments();
        }

        [Then(@"the list should contain '(.*)' documents")]
        public void ThenTheListShouldContainDocuments(int count)
        {
            _driver.Documents.Should().HaveCount(count);
        }
    }
}
