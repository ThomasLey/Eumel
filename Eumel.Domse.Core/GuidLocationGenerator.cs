namespace Eumel.Domse.Core
{
    public class GuidLocationGenerator
        : TreeBasedGenerator
    {
        public GuidLocationGenerator()
            : base("-", null)
        {
        }

        protected override string HierarchyProperty(DocumentMetadata doc)
        {
            return doc.Id.ToString();
        }
    }
}
