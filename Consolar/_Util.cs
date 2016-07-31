using System;
using System.Text.RegularExpressions;

namespace SteamB23.Consolar
{
    internal static class _Util
    {
        internal static Regex Line = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
        internal static Regex ColorCommand = new Regex(@"\[([c])\s(\w+)\]", RegexOptions.Compiled);
    }
}
