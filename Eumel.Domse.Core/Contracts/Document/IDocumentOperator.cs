using System;
using System.Collections.Generic;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.Core.Contracts
{
    public interface IDocumentOperator : IOperator
    {
        IEnumerable<DocumentInformation> GetDocumentList();
        DocumentInformation GetDocument(Guid id);
    }
}