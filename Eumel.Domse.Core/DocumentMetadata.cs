using System;
using System.Collections.Generic;

namespace Eumel.Domse.Core
{
    public class DocumentMetadata
    {
        public DocumentMetadata(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}