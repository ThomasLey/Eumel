using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core;

namespace Eumel.Domse.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "DomseDocument")]
    [OutputType(typeof(DocumentInformation))]
    public class GetDomseDocumentCmdlet : Cmdlet
    {
        private IDocumentOperator _documentOperator;

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
            HelpMessage = "Configuration file which is a '.eumel.config.json'",
            Mandatory = true)]
        [Alias("c", "config", "store")]
        public string Configuration { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (!System.IO.File.Exists(Configuration))
            {
                WriteError(new ErrorRecord(new FileNotFoundException("cannot fin configuration file", Configuration), "1000", ErrorCategory.ObjectNotFound, null));
                throw new FileNotFoundException("cannot fin configuration file", Configuration);
            }

            // todo; shitty shit. use operator here, therefore we have operator.
            _documentOperator = new DefaultDocumentOperator(new Lazy<IStorageService>(() =>
            {
                var factory = new ServiceFactory(Configuration);
                return factory.GetStorage();
            }));
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var result = _documentOperator.GetDocumentList().ToArray();
            WriteObject(result);
        }
    }
}
