using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
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
