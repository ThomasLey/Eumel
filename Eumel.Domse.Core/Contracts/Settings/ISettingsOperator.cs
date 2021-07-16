using System.Collections.Generic;
using Eumel.Domse.Core.Contracts;

namespace Eumel.Domse.BusinessLogic
{
    public interface ISettingsOperator : IOperator
    {
        IDictionary<string, string> GetSettings();
        
    }
}