using System;
using System.Diagnostics;
using System.Threading;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 콘솔창 텍스트 표시를 관리합니다.
    /// </summary>
    public static class ConsoleScreen
    {
        /// <summary>
        /// <see cref="ConsoleScreen"/>클래스의 정적 멤버가 호출될때 초기화되는 콘솔창의 높이입니다.
        /// </summary>
        public const int Top = 30;
        /// <summary>
        /// <see cref="ConsoleScreen"/>클래스의 정적 멤버가 호출될때 초기화되는 콘솔창의 너비입니다.
        /// </summary>
        public const int Left = 80;
        /// <summary>
        /// 콘솔창의 빈 공간을 채울때 사용되는 문자입니다.
        /// </summary>
        public const char Space = ' ';

        static ConsoleScreen()
        {
            Console.SetWindowSize(Left, Top);
            ConsoleEx.ResetColor();
            Console.Clear();
        }
        /// <summary>
        /// Consolar 라이브러리와 인코딩에 관한 정보를 출력합니다.
        /// </summary>
        public static void ShowInfomation()
        {
            Present("C o n s o l a r", 33, 5, 16, ConsoleColor.White);
            Present("Infomation", 35, 6, 10, ConsoleColor.Gray);
            Present("Console UI extension library", 20, 10, 40, ConsoleColor.Gray);
            Present("Copyright 2016 SteamB23", 20, 11, 40, ConsoleColor.Cyan);
            Present($"[c green]Output Encoding[c reset] : {Console.OutputEncoding.EncodingName}", 20, 13, 60, ConsoleColor.Gray);
            Present($"[c green]Input Encoding[c reset] : {Console.InputEncoding.EncodingName}", 20, 14, 60, ConsoleColor.Gray);
        }

        /// <summary>
        /// 지정된 텍스트와 좌표, 색 등을 사용하여 콘솔창에 텍스트를 출력합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public static void Present(string text, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            int asciiLength;
            try
            {
                asciiLength = Util.GetAsciiLength(text);
            }
            catch (ArgumentNullException)
            {
                asciiLength = 0;
            }
            InternalPresent(text, asciiLength, left, top, length, foregroundColor, backgroundColor, isRight);
        }
        /// <summary>
        /// <seealso cref="ConsoleText"/>클래스의 인스턴스를 사용하여 콘솔창에 텍스트를 출력합니다.
        /// </summary>
        /// <param name="consoleText"><seealso cref="ConsoleText"/>클래스의 인스턴스입니다.</param>
        public static void Present(ConsoleText consoleText)
        {
            InternalPresent(consoleText.Text, consoleText.asciiLength, consoleText.Left, consoleText.Top, consoleText.Length, consoleText.ForegroundColor, consoleText.BackgroundColor, consoleText.IsRight);
        }
        internal static void InternalPresent(string text, int asciiLength, int left, int top, int length, ConsoleColor foregroundColor, ConsoleColor backgroundColor, bool isRight)
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
                        ConsoleEx.Write(new string(' ', length - asciiLength) + text, foregroundColor, backgroundColor);
                    }
                    else
                    {
                        ConsoleEx.Write(text + new string(' ', length - asciiLength), foregroundColor, backgroundColor);
                    }
                    ConsoleEx.ResetColor();
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
