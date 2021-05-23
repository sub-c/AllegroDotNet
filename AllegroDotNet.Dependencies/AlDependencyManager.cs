using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Dependencies
{
    /// <summary>
    /// This class allows extracting the native DLLs needed by AllegroDotNet to a folder and making them available
    /// for use.
    /// </summary>
    public static class AlDependencyManager
    {
        private const string DefaultTemporaryFolderName = "AllegroDotNet";

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDllDirectory(string lpPathName);

        private static readonly IEnumerable<EmbeddedFileInfo> _embeddedDllFileInfos = new List<EmbeddedFileInfo>
        {
            new EmbeddedFileInfo("allegro_monolith-debug-5.2.dll", "SubC.AllegroDotNet.Dependencies.DLLs.allegro_monolith-debug-5.2.dll"),
            new EmbeddedFileInfo("brotlicommon.dll", "SubC.AllegroDotNet.Dependencies.DLLs.brotlicommon.dll"),
            new EmbeddedFileInfo("brotlidec.dll", "SubC.AllegroDotNet.Dependencies.DLLs.brotlidec.dll"),
            new EmbeddedFileInfo("bz2.dll", "SubC.AllegroDotNet.Dependencies.DLLs.bz2.dll"),
            new EmbeddedFileInfo("FLAC.dll", "SubC.AllegroDotNet.Dependencies.DLLs.FLAC.dll"),
            new EmbeddedFileInfo("FLAC++.dll", "SubC.AllegroDotNet.Dependencies.DLLs.FLAC++.dll"),
            new EmbeddedFileInfo("freetype.dll", "SubC.AllegroDotNet.Dependencies.DLLs.freetype.dll"),
            new EmbeddedFileInfo("libpng16.dll", "SubC.AllegroDotNet.Dependencies.DLLs.libpng16.dll"),
            new EmbeddedFileInfo("ogg.dll", "SubC.AllegroDotNet.Dependencies.DLLs.ogg.dll"),
            new EmbeddedFileInfo("opus.dll", "SubC.AllegroDotNet.Dependencies.DLLs.opus.dll"),
            new EmbeddedFileInfo("physfs.dll", "SubC.AllegroDotNet.Dependencies.DLLs.physfs.dll"),
            new EmbeddedFileInfo("theora.dll", "SubC.AllegroDotNet.Dependencies.DLLs.theora.dll"),
            new EmbeddedFileInfo("theoradec.dll", "SubC.AllegroDotNet.Dependencies.DLLs.theoradec.dll"),
            new EmbeddedFileInfo("theoraenc.dll", "SubC.AllegroDotNet.Dependencies.DLLs.theoraenc.dll"),
            new EmbeddedFileInfo("vorbis.dll", "SubC.AllegroDotNet.Dependencies.DLLs.vorbis.dll"),
            new EmbeddedFileInfo("vorbisenc.dll", "SubC.AllegroDotNet.Dependencies.DLLs.vorbisenc.dll"),
            new EmbeddedFileInfo("vorbisfile.dll", "SubC.AllegroDotNet.Dependencies.DLLs.vorbisfile.dll"),
            new EmbeddedFileInfo("zlib1.dll", "SubC.AllegroDotNet.Dependencies.DLLs.zlib1.dll")
        };

        /// <summary>
        /// Extracts the DLLs needed for the AllegroDotNet library, using the default output path of the user's
        /// temporary folder.
        /// </summary>
        public static void ExtractAllegroDotNetDlls()
            => ExtractAllegroDotNetDlls(Path.GetTempPath(), DefaultTemporaryFolderName);

        /// <summary>
        /// Extracts the DLLs needed for the AllegroDotNet library.
        /// </summary>
        /// <param name="outputPath">The base output folder to extract the DLLs to.</param>
        /// <param name="outputFolderName">The folder in the base output folder to place the DLLs to.</param>
        public static void ExtractAllegroDotNetDlls(string outputPath, string outputFolderName)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new NotSupportedException("Currently only Windows is supported by this method.");
            }

            var targetPath = EnsurePathEndsWithDirectorySeparator(outputPath);
            targetPath = EnsurePathEndsWithDirectorySeparator(targetPath + outputFolderName);
            Directory.CreateDirectory(targetPath);

            foreach (var embeddedDllFileInfo in _embeddedDllFileInfos)
            {
                CopyEmbeddedFileToLocalFile(embeddedDllFileInfo, new DirectoryInfo(targetPath));
            }

            if (!SetDllDirectory(targetPath))
            {
                throw new ApplicationException($"Could not set the DLL directory: {targetPath}");
            }
        }

        private static void CopyEmbeddedFileToLocalFile(EmbeddedFileInfo embeddedFileInfo, DirectoryInfo targetDirectory)
        {
            using (var embeddedDllFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedFileInfo.ResourceFullPath))
            {
                var targetFileFullPath = EnsurePathEndsWithDirectorySeparator(targetDirectory.FullName) + embeddedFileInfo.Filename;
                if (!IsFileAlreadyPresent(embeddedDllFileStream, targetFileFullPath))
                {
                    using (var localFileStream = File.Create(targetFileFullPath))
                    {
                        embeddedDllFileStream.CopyTo(localFileStream);
                        localFileStream.Flush();
                    }
                }
            }
        }

        private static string EnsurePathEndsWithDirectorySeparator(string path)
        {
            if (!path.EndsWith($"{Path.DirectorySeparatorChar}"))
            {
                path += Path.DirectorySeparatorChar;
            }
            return path;
        }

        private static bool IsFileAlreadyPresent(Stream embeddedFileStream, string localFileFullPath)
            => File.Exists(localFileFullPath) && new FileInfo(localFileFullPath).Length == embeddedFileStream.Length;
    }
}
