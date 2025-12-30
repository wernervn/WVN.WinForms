namespace WVN.WinForms.Utils;
internal static class IOHelper
{
    internal static string GetFolderName(string path)
        => GetLastTokenFromString(path, Path.DirectorySeparatorChar.ToString());

    internal static string GetLastTokenFromString(string text, string delimiter)
        => text.Split([delimiter], StringSplitOptions.None).Last();
}
