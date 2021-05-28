using System;
using System.Management.Automation;
using Eumel.Domse.Core.Exceptions;
using Eumel.Domse.PowerShell.Backend;
using StructureMap;

namespace Eumel.Domse.PowerShell.Cmdlets
{
    public class DomseCmdletBase : Cmdlet
    {
        private readonly Lazy<Container> _lazyContainer;

        [Parameter(
            HelpMessage = "Folder or endpoint which shall be used. Folder must contain '.eumel.config.json', rest service must start with http://",
            Mandatory = true)]
        [Alias("s")]
        public string Store { get; set; }

        public DomseCmdletBase()
        {
            _lazyContainer = new Lazy<Container>(()=> new Container(_ =>
            {
                try
                {
                    _.AddRegistry(new RegistryFactory(Store).Registry);
                }
                catch (EumelException eex)
                {
                    WriteWarning(eex.Message);
                    StopProcessing();
                }

                _.AddRegistry<OperatorRegistry>();
            }));
        }

        protected Container Container => _lazyContainer.Value;
    }
}
