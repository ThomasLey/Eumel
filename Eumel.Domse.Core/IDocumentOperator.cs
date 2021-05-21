using System;
using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public interface IDocumentOperator : IOperator
    {
        IEnumerable<DocumentInformation> GetDocumentList();
        DocumentInformation GetDocument(Guid id);
    }
}