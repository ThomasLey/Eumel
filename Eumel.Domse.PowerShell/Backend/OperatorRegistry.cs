using Eumel.Domse.BusinessLogic;
using Eumel.Domse.Core.Contracts;
using StructureMap;

namespace Eumel.Domse.PowerShell.Backend
{
    public class OperatorRegistry : Registry
    {
        public OperatorRegistry()
        {
            For<IDocumentOperator>().Use<DefaultDocumentOperator>().Singleton();
        }
    }
}
