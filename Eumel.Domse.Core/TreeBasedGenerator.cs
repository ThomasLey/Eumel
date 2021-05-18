namespace Eumel.Domse.Core
{
    public class TreeBasedGenerator : ILocationGenerator
    {
        private readonly string _hierarchySeparator;
        private readonly string _property;

        public TreeBasedGenerator(string hierarchySeparator, string property)
        {
            _hierarchySeparator = hierarchySeparator;
            _property = property;
        }

        public virtual string CreateFor(DocumentMetadata doc)
        {
            return HierarchyProperty(doc).Replace(_hierarchySeparator, "\\");
        }

        protected virtual string HierarchyProperty(DocumentMetadata doc)
        {
            return doc.Metadata[_property].Replace(_hierarchySeparator, "\\");
        }
    }

    public class FolderStorage
    {
        public FolderStorage()
        {
            
        }
    }

}