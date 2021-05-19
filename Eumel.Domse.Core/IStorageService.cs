using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public interface IStorageService
    {
        IEnumerable<DocumentInformation> DocumentList { get; }
    }
}