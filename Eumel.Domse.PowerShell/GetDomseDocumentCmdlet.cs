using System;
using System.Management.Automation;
using Eumel.Domse.Core;

namespace Eumel.Domse.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "DomseDocument")]
    [OutputType(typeof(DocumentInformation))]
    public class GetDomseDocumentCmdlet : Cmdlet
    {
        private IStorageService _storage;

        [Parameter(
            HelpMessage = "File which should be added to the storage",
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
            )]
        [Alias("f", "filename", "path")]
        public string[] File { get; set; }

        [Parameter(
            HelpMessage = "Configuration file or folder which contains a '.eumel.config.json'. If not provided, the working directory is used.")]
        [Alias("c", "config", "store")]
        public string Configuration { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _storage = new FolderStorageService(Configuration);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var result = new DocumentInformation() {Id = Guid.Empty};
            result.Metadata.Add("Foo", "Bar");
            result.Metadata.Add("Hello", "World");
            WriteObject(result);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}
