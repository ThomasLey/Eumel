using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eumel.Domse.Core.Database;

namespace Eumel.Domse.Database.Entity
{
    public class Document : IGuidEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Description("location of the file relatively to the store's root")]
        public string Source { get; set; }
        
        [Description("mime type of the document")]
        public string DocType { get; set; }

        [Description("list of all properties gathered from the document or added manually")]
        [InverseProperty(nameof(DocumentProperty.Document))]
        public virtual ICollection<DocumentProperty> DocumentProperties { get; } = new HashSet<DocumentProperty>();
    }
}
