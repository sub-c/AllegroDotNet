namespace SubC.AllegroDotNet.Dependencies
{
    internal sealed class EmbeddedFileInfo
    {
        public string ResourceFullPath { get; } = string.Empty;
        public string Filename { get; } = string.Empty;

        public EmbeddedFileInfo(string filename, string embeddedFileFullPath)
        {
            ResourceFullPath = embeddedFileFullPath;
            Filename = filename;
        }
    }
}
