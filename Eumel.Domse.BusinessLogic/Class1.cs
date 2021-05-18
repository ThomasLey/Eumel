using System;
using System.Collections.Generic;
using System.Linq;
using Eumel.Domse.Core;

namespace Eumel.Domse.BusinessLogic
{
    public class DocumentManagementOperator : IDocumentManagementOperator
    {
        private readonly Lazy<IDocumentStorage> _storage;

        public DocumentManagementOperator(Lazy<IDocumentStorage> storage)
        {
            _storage = storage;
        }

        public IEnumerable<DocumentInformation> GetDocumentList => GetAllDocuments(x => true);

        private IEnumerable<DocumentInformation> GetAllDocuments(Func<DocumentInformation, bool> search)
        {
            return _storage.Value.DocumentList.Where(search).ToArray();
        }
    }

    public interface IDocumentStorage
    {
        IEnumerable<DocumentInformation> DocumentList { get; }
    }

    public interface IDocumentManagementOperator
    {
        IEnumerable<DocumentInformation> GetDocumentList { get; }
    }
}
