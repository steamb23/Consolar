using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SteamB23.Consolar
{
    internal static class _Util
    {
        internal static Regex Line = new Regex("\r\n|\r|\n", RegexOptions.Compiled);
    }
}
