using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Eumel.Domse.Specflow.Drivers
{
    internal class PowershellCmdletDriver
    {
        private readonly Dictionary<string, string> _parameter = new();
        public Cmdlet Cmdlet { get; set; }

        public void AddParameter(string key, string value)
        {
            _parameter.Add(key, value);
        }

        public void Execute()
        {
            foreach (var propertyInfo in typeof(Cmdlet).GetProperties().Where(x => CustomAttributeExtensions.GetCustomAttribute<ParameterAttribute>((MemberInfo) x) != null))
            {
                propertyInfo.SetValue(Cmdlet, _parameter[propertyInfo.Name]);
            }

            Result = Cmdlet.Invoke();
        }

        public IEnumerable Result { get; set; }
    }
}