using System;
using System.Text.RegularExpressions;

namespace SteamB23.Consolar
{
    internal static class _Util
    {
        internal const string ConsoleTags = "fc|bc|c";

        internal static Regex LineRegex = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
        internal static Regex ConsoleTagRegex = new Regex(@"\[("+ ConsoleTags + @")\s(\w+)\]", RegexOptions.Compiled);
    }
}
