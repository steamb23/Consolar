using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    public static class ConsoleEx
    {
        public static void WriteLine(string value, ConsoleColor defaultForegroundColor = ConsoleColor.Gray, ConsoleColor defaultBackgroundColor = ConsoleColor.Black)
        {
            Write(value, defaultForegroundColor, defaultBackgroundColor);
            Console.WriteLine();
        }
        public static void Write(string value, ConsoleColor defaultForegroundColor = ConsoleColor.Gray, ConsoleColor defaultBackgroundColor = ConsoleColor.Black)
        {
            string[] tagSplitText = _Util.ConsoleTagRegex.Split(value);
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
