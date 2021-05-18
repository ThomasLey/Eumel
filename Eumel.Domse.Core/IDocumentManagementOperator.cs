using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public interface IDocumentManagementOperator
    {
        IEnumerable<DocumentInformation> GetDocumentList { get; }
    }
}