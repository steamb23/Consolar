using System;
using System.Text.RegularExpressions;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 유틸리티 메서드를 제공하는 정적 클래스입니다.
    /// </summary>
    public static class Util
    {
        internal const string ConsoleTags = "fc|bc|c";

        internal static Regex LineRegex = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
        internal static Regex ConsoleTagRegex = new Regex(@"\[("+ ConsoleTags + @")\s(\w+)\]", RegexOptions.Compiled);

        /// <summary>
        /// ASCII 문자열의 바이트 길이를 가져옵니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetAsciiLength(string value)
        {
            return Console.OutputEncoding.GetByteCount(ConsoleTagRegex.Replace(value, ""));
        }
    }
}
