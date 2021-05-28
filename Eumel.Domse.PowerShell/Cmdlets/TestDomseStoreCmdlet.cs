using System.Management.Automation;
using Eumel.Domse.Core.Exceptions;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.PowerShell.Cmdlets
{
    [Cmdlet("Test", "DomseStore")]
    [OutputType(typeof(DocumentInformation))]
    // ReSharper disable once UnusedMember.Global
    public class TestDomseStoreCmdlet : DomseCmdletBase
    {
        private EumelConfiguration _config;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            _config = Container.GetInstance<EumelConfiguration>();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var isValid = _config.Validate(out var message);
            WriteObject(isValid);
        }
    }
}
