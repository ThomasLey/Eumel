using System;
using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public class DocumentInformation
    {
        public Guid Id { get; set; }
        public Dictionary<string, string> Metadata { get; } = new Dictionary<string, string>();
    }
}
