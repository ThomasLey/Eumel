using TechTalk.SpecFlow;

namespace Eumel.Domse.Specflow.Hooks
{
    [Binding]
    public class StoragePreparation
    {
        private ScenarioContext _scenarioContext;
        private static string _location;

        public StoragePreparation(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRunInjection(ITestRunnerManager testRunnerManager, ITestRunner testRunner)
        {
            _location = testRunnerManager.TestAssembly.Location;
        }

        [BeforeFeature(Order = 0)]
        public static void EmptyStorageFolder()
        {
        }
        
        [BeforeFeature(Order = 100)]
        public static void AddSampleDocuments()
        {
        }
    }
}
