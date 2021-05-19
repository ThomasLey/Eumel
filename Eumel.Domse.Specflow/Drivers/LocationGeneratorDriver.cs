using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core;
using Eumel.Domse.PowerShell;

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

    internal class LocationGeneratorDriver
    {
        public ILocationGenerator Generator { get; set; }
        public Guid Id { get; set; }
        public Dictionary<string, string> Property { get; } = new();
        public string GeneratedFolder { get; private set; }

        public void GenerateFolder()
        {
            GeneratedFolder = Generator.CreateFor(new DocumentMetadata(Id) { Metadata = Property });
        }
    }

    internal class PowershellCmdletDriver
    {
        private readonly Dictionary<string, string> _parameter = new();
        public Cmdlet Cmdlet { get; set; }

        public void AddParameter(string key, string value)
        {
            _parameter.Add(key, value);
        }

        public void Execute()
        {
            foreach (var propertyInfo in typeof(Cmdlet).GetProperties().Where(x => x.GetCustomAttribute<ParameterAttribute>() != null))
            {
                propertyInfo.SetValue(Cmdlet, _parameter[propertyInfo.Name]);
            }

            Result = Cmdlet.Invoke();
        }

        public IEnumerable Result { get; set; }
    }
}
