using System;
using System.Collections.Generic;

namespace Eumel.Domse.Core.Model
{
    public class DocumentInformation
    {
        public Guid Id { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
        public string Name { get; set; }
    }
}
