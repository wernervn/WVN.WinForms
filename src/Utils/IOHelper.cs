using System;
using System.IO;
using WVN.WinForms.Extensions;
using static WVN.WinForms.Utils.StringHelper;

namespace WVN.WinForms.Utils
{
    internal static class IOHelper
    {
        internal static string CleanDirectoryName(string path)
            => path.ReplaceAllChars(Path.GetInvalidPathChars(), ' ');

        internal static string CleanFileName(string path)
            => path.ReplaceAllChars(Path.GetInvalidFileNameChars(), ' ');

        internal static string GetRandomFileName()
            => GetRandomFileName(Path.GetTempPath());

        internal static string GetRandomFileName(string path)
            => GetRandomFileName(path, ".tmp");

        internal static string GetRandomFileName(string path, string extension)
            => Path.Combine(path, string.Format("{0}.{1}", Guid.NewGuid(), extension));

        internal static string GetFolderName(string path)
            => GetLastTokenFromString(path, Path.DirectorySeparatorChar.ToString());

        internal static string GetFileNameFromUrl(string url)
            => GetLastTokenFromString(url, "/");
    }

}
