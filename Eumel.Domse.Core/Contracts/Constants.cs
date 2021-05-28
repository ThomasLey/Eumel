namespace Eumel.Domse.Core.Contracts
{
    public static class Constants
    {
        // name of the file which contains the storage configuration e.g. provider for metadata or folder creation strategy
        public static string ConfigJson = ".eumel.config.json";
        
        // extension of files which contain metadata for a file. Only required if metadata is stored side-by-side with files.
        public const string MetadataExtension = ".eumel.metadata.json";

    }
}
