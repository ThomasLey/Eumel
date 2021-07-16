using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eumel.Domse.Core.Database;

namespace Eumel.Domse.Database.Entity
{
    public class SemanticMapping : IGuidEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Description("mime type of the document")]
        public string DocType { get; set; }

        [Description("original name of the property. required e.g. if 're-analysed'")]
        public string OriginalKey { get; set; }

        [Description("semantic name based on mapping")]
        public string SemanticName { get; set; }
    }
}