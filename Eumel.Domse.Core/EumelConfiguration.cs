using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Eumel.Domse.Core
{
    public class EumelConfiguration
    {
        public static EumelConfiguration Load(string configFile)
        {
            var result = JsonConvert.DeserializeObject<EumelConfiguration>(File.ReadAllText(configFile));
            if (result.StorageEndpoint == "{local}")
                result.StorageEndpoint = new FileInfo(configFile).DirectoryName;

            return result;
        }

        public bool Validate(out string messages)
        {
            var result = new StringBuilder();
            
            if (StorageType != "FolderStorageService")
                result.AppendLine("Parameter 'StorageType' only support 'FolderStorageService'");

            messages = result.ToString();
            return messages.IsNullOrEmpty();
        }
        
        public string StorageType { get; set; }
        public string StorageEndpoint { get; set; }
    }
}