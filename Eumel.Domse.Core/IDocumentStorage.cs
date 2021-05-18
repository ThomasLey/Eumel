using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public interface IDocumentStorage
    {
        IEnumerable<DocumentInformation> DocumentList { get; }
    }
}