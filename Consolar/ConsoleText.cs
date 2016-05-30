using System;

namespace SteamB23.Consolar
{
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
        public ConsoleText(int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false) :
            this(string.Empty, left, top, length, foregroundColor, backgroundColor, isRight)
        {
        }
        #endregion
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
                asciiLength = System.Console.OutputEncoding.GetByteCount(value);

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
        public int Length
        {
            get
            {
                return length;
            }
        }
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

        public void Present()
        {
            Screen.Present(this);
        }
        public void Depresent()
        {
            Screen.Present(new string(' ', asciiLength), left, top, length);
        }
    }
}
