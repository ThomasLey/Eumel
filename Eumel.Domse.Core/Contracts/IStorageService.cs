using System.Collections.Generic;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.Core.Contracts
{
    public interface IStorageService
    {
        IEnumerable<DocumentInformation> DocumentList { get; }
    }
}