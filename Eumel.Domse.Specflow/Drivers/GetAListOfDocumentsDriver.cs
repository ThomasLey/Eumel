using System;
using System.Collections.Generic;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core;

namespace Eumel.Domse.Specflow.Drivers
{
    internal class GetAListOfDocumentsDriver
    {
        public string StoragePath { get; set; }
        public IStorageService StorageService { get; set; }
        public IEnumerable<DocumentInformation> Documents { get; set; }

        public IEnumerable<DocumentInformation> GetDocuments()
        {
            var ops = new DocumentOperator(new Lazy<IStorageService>(StorageService));
            return ops.GetDocumentList();
        }
    }
}