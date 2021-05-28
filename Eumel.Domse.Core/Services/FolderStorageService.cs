using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Model;
using Newtonsoft.Json;

namespace Eumel.Domse.Core.Services
{
    public class FolderStorageService : IStorageService
    {
        private const string MetadataExtension = ".eumel.metadata.json";
        private readonly string _endpoint;

        public FolderStorageService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public IEnumerable<DocumentInformation> DocumentList
        {
            get
            {
                var files = new DirectoryInfo(_endpoint)
                    .GetFiles("*.*", searchOption: SearchOption.AllDirectories)
                    .Where(x => !x.Name.EndsWith(MetadataExtension));
                var infos = files
                    .Select(x => new DocumentInformation()
                    {
                        Name = x.Name,
                        Metadata = GetDictionaryFor(x.FullName + MetadataExtension),
                        Id = Guid.Parse(GetDictionaryFor(x.FullName + MetadataExtension)["_id"])
                    });
                return infos;
            }
        }

        private static Dictionary<string, string> GetDictionaryFor(string filename)
        {
            var json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }
}
