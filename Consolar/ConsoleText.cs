using System;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 콘솔에 텍스트를 표시할 수 있는 데이터를 포함합니다.
    /// </summary>
    public class ConsoleText : IPresentable
    {
        string text;
        int left;
        int top;
        int length;
        ConsoleColor foregroundColor;
        ConsoleColor backgroundColor;
        bool isRight;
        internal int asciiLength;

        #region 생성자
        // 기본
        /// <summary>
        /// 지정된 텍스트와 위치, 길이, 색 등을 사용하여 <see cref="ConsoleText"/>를 초기화합니다.
        /// </summary>
        /// <param name="text">출력할 텍스트입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public ConsoleText(string text, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            this.length = length;
            this.Text = text;
            this.Left = left;
            this.Top = top;
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
            this.IsRight = isRight;
        }
        // Empty
        /// <summary>
        /// 지정된 위치와 길이, 색 등을 사용하여 <see cref="ConsoleText"/>를 초기화합니다.
        /// </summary>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public ConsoleText(int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false) :
            this(string.Empty, left, top, length, foregroundColor, backgroundColor, isRight)
        {
        }
        #endregion
        /// <summary>
        /// 텍스트를 설정하거나 가져옵니다.
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                value = _Util.Line.Replace(value, " ");

                int asciiLength;
                if (value == null)
                    value = "";
                asciiLength = System.Console.OutputEncoding.GetByteCount(_Util.ColorCommand.Replace(value, ""));

                if (asciiLength <= length)
                {
                    this.text = value;
                    this.asciiLength = asciiLength;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "value의 길이는 Element.Length보다 클 수 없습니다.");
                }
            }
        }
        /// <summary>
        /// 열 위치를 가져오거나 설정합니다.
        /// </summary>
        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                this.left = value;
            }
        }
        /// <summary>
        /// 행 위치를 가져오거나 설정합니다.
        /// </summary>
        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                this.top = value;
            }
        }
        /// <summary>
        /// 최대 길이를 가져오거나 설정합니다.
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
        }
        /// <summary>
        /// 전경색을 가져오거나 설정합니다.
        /// </summary>
        public ConsoleColor ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
            set
            {
                this.foregroundColor = value;
            }
        }
        /// <summary>
        /// 배경색을 가져오거나 설정합니다.
        /// </summary>
        public ConsoleColor BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                this.backgroundColor = value;
            }
        }
        /// <summary>
        /// 오른쪽 정렬 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsRight
        {
            get
            {
                return isRight;
            }
            set
            {
                this.isRight = value;
            }
        }

        /// <summary>
        /// 이 인스턴스를 사용하여 콘솔창에 출력합니다.
        /// </summary>
        public void Present()
        {
            Screen.Present(this);
        }
        /// <summary>
        /// 이 인스턴스의 위치에 출력했던 내용을 제거합니다.
        /// </summary>
        public void Depresent()
        {
            Screen.Present(new string(' ', asciiLength), left, top, length);
        }
    }
}
