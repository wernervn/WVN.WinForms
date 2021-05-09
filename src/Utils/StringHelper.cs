using System;
using System.Linq;

namespace WVN.WinForms.Utils
{
    internal static class StringHelper
    {
        internal static string GetLastTokenFromString(string text, string delimiter)
            => text.Split(new string[] { delimiter }, StringSplitOptions.None).Last();
    }
}
