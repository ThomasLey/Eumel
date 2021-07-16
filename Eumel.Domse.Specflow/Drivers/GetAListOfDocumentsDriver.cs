using System;
using System.Collections.Generic;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.Specflow.Drivers
{
    internal class GetAListOfDocumentsDriver
    {
        public string StoragePath { get; set; }
        public IStorageService StorageService { get; set; }
        public IEnumerable<DocumentInformation> Documents { get; set; }
        public DocumentInformation Document { get; set; }

        public IEnumerable<DocumentInformation> GetDocuments()
        {
            var ops = new DefaultDocumentOperator(new Lazy<IStorageService>(StorageService));
            return ops.GetDocumentList();
        }

        public DocumentInformation GetDocumentWithId(Guid id)
        {
            var ops = new DefaultDocumentOperator(new Lazy<IStorageService>(StorageService));
            return ops.GetDocument(id);
        }
    }
}