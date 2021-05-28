using System;
using System.Collections.Generic;
using System.Linq;
using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.BusinessLogic
{
    public class DefaultDocumentOperator : IDocumentOperator
    {
        private readonly Lazy<IStorageService> _storage;

        public DefaultDocumentOperator(Lazy<IStorageService> storage)
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
