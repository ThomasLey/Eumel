using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eumel.Domse.Core.Database;

namespace Eumel.Domse.Database.Entity
{
    public class DocumentProperty : IGuidEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Description("semantic name based on mapping. can be empty")]
        public string SemanticName { get; set; }
        
        [Description("original name of the property. required e.g. if 're-analysed'")]
        public string OriginalKey { get; set; }
        
        [Description("value of the property")]
        public string Value { get; set; }
        
        [Description("indicated if the property was automatically created")]
        public PropertyType PropertyType { get; set; }
        
        public virtual Document Document { get; set; }

    }
}