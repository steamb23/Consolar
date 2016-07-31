using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    public static class ConsoleEx
    {
        public static void WriteLine(string value, ConsoleColor defaultColor = ConsoleColor.Gray)
        {
            Write(value, defaultColor);
            Console.WriteLine();
        }
        public static void Write(string value, ConsoleColor defaultColor = ConsoleColor.Gray)
        {
            string[] commandText = _Util.ColorCommand.Split(value);
            Console.Write(commandText[0]);
            for (int i = 1; i + 2 < commandText.Length; i++)
            {
                string command = commandText[i++];
                string arg = commandText[i++];

                switch (command)
                {
                    case "c":
                        ConsoleColor commandedColor;
                        if (!Enum.TryParse(arg, true, out commandedColor))
                        {
                            if (arg.ToLower() == "reset")
                                Console.ForegroundColor = defaultColor;
                            break;
                        }
                        Console.ForegroundColor = commandedColor;
                        break;
                }

                Console.Write(commandText[i]);
            }
        }
    }
}
