using System.IO;
using System.Management.Automation;
using Eumel.Domse.Core;

namespace Eumel.Domse.PowerShell
{
    [Cmdlet("Test", "DomseStore")]
    [OutputType(typeof(DocumentInformation))]
    // ReSharper disable once UnusedMember.Global
    public class TestDomseStoreCmdlet : Cmdlet
    {
        private EumelConfiguration _config;

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
                WriteError(new ErrorRecord(new FileNotFoundException("cannot find configuration file", Configuration), "1000", ErrorCategory.ObjectNotFound, null));
                throw new FileNotFoundException("cannot find configuration file", Configuration);
            }

            _config = EumelConfiguration.Load(Configuration);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var isValid = _config.Validate(out var message);
            if (!isValid)
            {
                WriteWarning(EumelConfigurationException.ErrorMessage + " " + _config.StorageEndpoint);
                WriteInformation(new InformationRecord(message, _config.StorageEndpoint));
                WriteError(new ErrorRecord(new EumelConfigurationException(message),
                    EumelConfigurationException.ErrorId, ErrorCategory.NotSpecified, _config));
            }

            WriteObject(isValid);
        }
    }
}
