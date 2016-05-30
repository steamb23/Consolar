using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamB23.Consolar
{
    public static class Screen
    {
        public const int Top = 30;
        public const int Left = 80;
        public const char Space = ' ';

        static Screen()
        {
            Debug.WriteLine($"Ouput Encoding : {Console.OutputEncoding.EncodingName}");
            Debug.WriteLine($"Input Encoding : {Console.InputEncoding.EncodingName}");
            Console.SetWindowSize(Left, Top);
        }

        public static void Present(string text, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            int asciiLength;
            try
            {
                asciiLength = Console.OutputEncoding.GetByteCount(text);
            }
            catch (ArgumentNullException)
            {
                asciiLength = 0;
            }
            InternalDraw(text, asciiLength, left, top, length, foregroundColor, backgroundColor, isRight);
        }
        public static void Present(ConsoleText consoleText)
        {
            InternalDraw(consoleText.Text, consoleText.asciiLength, consoleText.Left, consoleText.Top, consoleText.Length, consoleText.ForegroundColor, consoleText.BackgroundColor, consoleText.IsRight);
        }
        internal static void InternalDraw(string text, int asciiLength, int left, int top, int length, ConsoleColor foregroundColor, ConsoleColor backgroundColor, bool isRight)
        {
            if (left + asciiLength < Left)
            {
                if (top <= Top)
                {
                    Console.SetCursorPosition(left, top);
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    if (isRight)
                    {
                        Console.WriteLine(new string(' ', length - asciiLength) + text);
                    }
                    else
                    {
                        Console.WriteLine(text + new string(' ', length - asciiLength));
                    }
                    Console.ResetColor();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
