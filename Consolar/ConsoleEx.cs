using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    /// <summary>
    /// <see cref="Console"/>의 기능을 확장한 메서드를 포함하는 정적 클래스입니다.
    /// </summary>
    public static class ConsoleEx
    {
        /// <summary>
        /// 뒤에 현재 줄 종결자가 오는, 지정한 문자열 값을 확장 기능을 이용하여 씁니다.
        /// </summary>
        /// <param name="value">쓸 값입니다.</param>
        /// <param name="defaultForegroundColor">reset명령시 사용될 기본 문자 색입니다.</param>
        /// <param name="defaultBackgroundColor">reset명령시 사용될 기본 배경 색입니다.</param>
        public static void WriteLine(string value, ConsoleColor defaultForegroundColor = ConsoleColor.Gray, ConsoleColor defaultBackgroundColor = ConsoleColor.Black)
        {
            Write(value, defaultForegroundColor, defaultBackgroundColor);
            Console.WriteLine();
        }
        /// <summary>
        /// 지정한 문자열 값을 확장 기능을 이용하여 씁니다.
        /// </summary>
        /// <param name="value">쓸 값입니다.</param>
        /// <param name="defaultForegroundColor">reset명령시 사용될 기본 문자 색입니다.</param>
        /// <param name="defaultBackgroundColor">reset명령시 사용될 기본 배경 색입니다.</param>
        public static void Write(string value, ConsoleColor defaultForegroundColor = ConsoleColor.Gray, ConsoleColor defaultBackgroundColor = ConsoleColor.Black)
        {
            string[] tagSplitText = Util.ConsoleTagRegex.Split(value);
            Console.Write(tagSplitText[0]);
            for (int i = 1; i + 2 < tagSplitText.Length; i++)
            {
                string command = tagSplitText[i++].ToLower();
                string arg = tagSplitText[i++].ToLower();

                switch (command)
                {
                    case "c":
                    case "fc":
                        SetForegroundColor(arg, defaultForegroundColor);
                        break;
                    case "bc":
                        SetBackgroundColor(arg, defaultBackgroundColor);
                        break;
                }

                Console.Write(tagSplitText[i]);
            }
        }
        /// <summary>
        /// 색을 초기화합니다.
        /// </summary>
        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void SetForegroundColor(string arg, ConsoleColor defaultForegroundColor)
        {
            ConsoleColor commandedColor;
            if (!Enum.TryParse(arg, true, out commandedColor))
            {
                if (arg == "reset")
                    Console.ForegroundColor = defaultForegroundColor;
                return;
            }
            Console.ForegroundColor = commandedColor;
        }
        static void SetBackgroundColor(string arg, ConsoleColor defaultBackgroundColor)
        {
            ConsoleColor commandedColor;
            if (!Enum.TryParse(arg, true, out commandedColor))
            {
                if (arg == "reset")
                    Console.BackgroundColor = defaultBackgroundColor;
                return;
            }
            Console.BackgroundColor = commandedColor;
        }
    }
}
