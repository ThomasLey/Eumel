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

        [When(@"a documents with id '(.*)' is requested")]
        public void WhenADocumentsWithIdIsRequested(string id)
        {
            _driver.Document = _driver.GetDocumentWithId(Guid.Parse(id));
        }

        [Then(@"the list should contain '(.*)' documents")]
        public void ThenTheListShouldContainDocuments(int count)
        {
            _driver.Documents.Should().HaveCount(count);
        }

        [Then(@"the list should contain '(.*)'")]
        public void ThenTheListShouldContain(string filename)
        {
            _driver.Documents.Should().Contain(x => x.Name == filename);
        }

        [Then(@"the list should not contain '(.*)'")]
        public void ThenTheListShouldNotContain(string filename)
        {
            _driver.Documents.Should().NotContain(x => x.Name == filename);
        }

        [Then(@"the document id for '(.*)' should be '(.*)'")]
        public void ThenTheListIdForShouldBe(string filename, string id)
        {
            _driver.Documents.Should().Contain(x => x.Name == filename && x.Id == Guid.Parse(id));
        }

        [Then(@"the name should be '(.*)'")]
        public void ThenTheNameShouldBe(string name)
        {
            _driver.Document.Name.Should().Be(name);
        }
    }
}
