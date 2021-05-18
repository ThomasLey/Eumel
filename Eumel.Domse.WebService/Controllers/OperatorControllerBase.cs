using Eumel.Domse.Core;
using Microsoft.AspNetCore.Mvc;

namespace Eumel.Domse.WebService.Controllers
{
    public abstract class OperatorControllerBase<T> : ControllerBase
        where T : IOperator
    {
        public T Operator { get; set; }

    }
}