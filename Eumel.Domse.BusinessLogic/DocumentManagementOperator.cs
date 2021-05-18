using System;
using System.Collections.Generic;
using System.Linq;
using Eumel.Domse.Core;

namespace Eumel.Domse.BusinessLogic
{
    public class DocumentOperator : IDocumentOperator
    {
        private readonly Lazy<IDocumentStorage> _storage;

        public DocumentOperator(Lazy<IDocumentStorage> storage)
        {
            _storage = storage;
        }

        public IEnumerable<DocumentInformation> GetDocumentList()
        {
            return GetAllDocumentsWhere(_ => true);
        }

        public DocumentInformation GetDocument(Guid id)
        {
            return GetAllDocumentsWhere(x => x.Id == id).Single();
        }

        private IEnumerable<DocumentInformation> GetAllDocumentsWhere(Func<DocumentInformation, bool> search)
        {
            return _storage.Value.DocumentList.Where(search).ToArray();
        }
    }
}
