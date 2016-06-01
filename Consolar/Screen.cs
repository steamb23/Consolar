using System;
using System.Diagnostics;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 콘솔창 텍스트 표시를 관리합니다.
    /// </summary>
    public static class Screen
    {
        /// <summary>
        /// <see cref="Screen"/>클래스의 정적 멤버가 호출될때 초기화되는 콘솔창의 높이입니다.
        /// </summary>
        public const int Top = 30;
        /// <summary>
        /// <see cref="Screen"/>클래스의 정적 멤버가 호출될때 초기화되는 콘솔창의 너비입니다.
        /// </summary>
        public const int Left = 80;
        /// <summary>
        /// 콘솔창의 빈 공간을 채울때 사용되는 문자입니다.
        /// </summary>
        public const char Space = ' ';

        static Screen()
        {
            Debug.WriteLine($"Ouput Encoding : {Console.OutputEncoding.EncodingName}");
            Debug.WriteLine($"Input Encoding : {Console.InputEncoding.EncodingName}");
            Console.SetWindowSize(Left, Top);
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
                asciiLength = Console.OutputEncoding.GetByteCount(text);
            }
            catch (ArgumentNullException)
            {
                asciiLength = 0;
            }
            InternalDraw(text, asciiLength, left, top, length, foregroundColor, backgroundColor, isRight);
        }
        /// <summary>
        /// <seealso cref="ConsoleText"/>클래스의 인스턴스를 사용하여 콘솔창에 텍스트를 출력합니다.
        /// </summary>
        /// <param name="consoleText"><seealso cref="ConsoleText"/>클래스의 인스턴스입니다.</param>
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
