using System.Management.Automation;
using Eumel.Domse.Core.Exceptions;

namespace Eumel.Domse.PowerShell
{
    public static class CmdletExtensions
    {
        public static ErrorRecord ToErrorRecord(this EumelException exception)
        {
            return new ErrorRecord(
                exception, exception.ErrorId.ToString(), ErrorCategory.ConnectionError, null);
        }
    }
}
