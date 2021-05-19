using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eumel.Domse.Core
{
    public class FolderStorageService : IStorageService
    {
        private readonly string _endpoint;

        public FolderStorageService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public IEnumerable<DocumentInformation> DocumentList
        {
            get
            {
                var files = new DirectoryInfo(_endpoint).GetFiles("*.*", searchOption: SearchOption.AllDirectories);
                var infos = files.Select(x => new DocumentInformation() { Name = x.Name });
                return infos;
            }
        }
    }
}
