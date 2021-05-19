using System;
using System.Collections.Generic;
using Eumel.Domse.Core;
using Eumel.Domse.PowerShell;

namespace Eumel.Domse.Specflow.Drivers
{
    internal class LocationGeneratorDriver
    {
        public ILocationGenerator Generator { get; set; }
        public Guid Id { get; set; }
        public Dictionary<string, string> Property { get; } = new();
        public string GeneratedFolder { get; private set; }

        public void GenerateFolder()
        {
            GeneratedFolder = Generator.CreateFor(new DocumentMetadata(Id) { Metadata = Property });
        }
    }
}
