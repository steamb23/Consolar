using System;

namespace SteamB23.Consolar.UI
{
    /// <summary>
    /// 콘솔에 여러줄의 텍스트를 표시하도록 여러 ConsoleText를 포함합니다.
    /// </summary>
    public class TextBox : IPresentable
    {
        ConsoleText[] consoleTexts;
        string originText;

        /// <summary>
        /// 텍스트를 가져오거나 설정합니다.
        /// </summary>
        public string Text
        {
            get
            {
                return originText;
            }
            set
            {
                var textLines = SplitText(value);
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].Text =
                        i < textLines.Length ?
                        textLines[i] :
                        string.Empty;
                }
                originText = value;
            }
        }
        /// <summary>
        /// <seealso cref="ConsoleText"/>의 인스턴스 배열을 가져옵니다.
        /// </summary>
        public ConsoleText[] ConsoleTexts
        {
            get
            {
                return this.consoleTexts;
            }
        }
        /// <summary>
        /// 열의 최대 길이를 가져옵니다.
        /// </summary>
        public int Row
        {
            get
            {
                return consoleTexts.Length;
            }
        }
        /// <summary>
        /// 열 위치를 가져오거나 설정합니다.
        /// </summary>
        public int Left
        {
            get
            {
                return consoleTexts[0].Left;
            }

            set
            {
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].Left = value;
                }
            }
        }
        /// <summary>
        /// 행 위치를 가져오거나 설정합니다.
        /// </summary>
        public int Top
        {
            get
            {
                return consoleTexts[0].Top;
            }
            set
            {
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].Left = value + i;
                }
            }
        }

        /// <summary>
        /// 최대 길이를 가져오거나 설정합니다.
        /// </summary>
        public int Length
        {
            get
            {
                return consoleTexts[0].Length;
            }
        }
        /// <summary>
        /// 오른쪽 정렬 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsRight
        {
            get
            {
                return consoleTexts[0].IsRight;
            }
            set
            {
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].IsRight = value;
                }
            }
        }


        /// <summary>
        /// 전경색을 가져오거나 설정합니다.
        /// </summary>
        public ConsoleColor ForegroundColor
        {
            get
            {
                return consoleTexts[0].ForegroundColor;
            }
            set
            {
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].ForegroundColor = value;
                }
            }
        }
        /// <summary>
        /// 배경색을 가져오거나 설정합니다.
        /// </summary>
        public ConsoleColor BackgroundColor
        {
            get
            {
                return consoleTexts[0].BackgroundColor;
            }
            set
            {
                for (int i = 0; i < consoleTexts.Length; i++)
                {
                    consoleTexts[i].BackgroundColor = value;
                }
            }
        }
        #region 생성자
        // Multiline string
        /// <summary>
        /// 열의 최대 갯수와 텍스트, 위치, 길이, 색상 등을 사용하여 <see cref="TextBox"/>클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="row">열의 최대 갯수입니다.</param>
        /// <param name="text">출력할 텍스트입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public TextBox(int row, string text, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            consoleTexts = new ConsoleText[row];
            var textLines = SplitText(text);
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i] =
                    i < textLines.Length ?
                    new ConsoleText(textLines[i], left, top + i, length, foregroundColor, backgroundColor, isRight) :
                    new ConsoleText(left, top + i, length, foregroundColor, backgroundColor, isRight);
            }

        }
        // strings
        /// <summary>
        /// 열의 최대 갯수와 텍스트 배열, 위치, 길이, 색상 등을 사용하여 <see cref="TextBox"/>클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="row">열의 최대 갯수입니다.</param>
        /// <param name="texts">출력할 텍스트의 배열입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public TextBox(int row, string[] texts, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            consoleTexts = new ConsoleText[row];
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i] =
                    i < texts.Length ?
                    new ConsoleText(texts[i], left, top + i, length, foregroundColor, backgroundColor, isRight) :
                    new ConsoleText(left, top + i, length, foregroundColor, backgroundColor, isRight);
            }
        }
        /// <summary>
        /// 텍스트의 배열과 위치, 길이, 색상 등을 사용하여 <see cref="TextBox"/>클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="texts">출력할 텍스트의 배열입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public TextBox(string[] texts, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false) : this (texts.Length,texts,left,top,length,foregroundColor,backgroundColor,isRight)
        {
        }
        // Empty
        /// <summary>
        /// 열의 최대 갯수와 위치, 길이, 색상 등을 사용하여 <see cref="TextBox"/>클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="row">열의 최대 갯수입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">출력할 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">출력할 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public TextBox(int row, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            consoleTexts = new ConsoleText[row];
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i] =
                    new ConsoleText(left, top + i, length, foregroundColor, backgroundColor, isRight);
            }

        }

        #endregion
        /// <summary>
        /// 이 인스턴스의 내용을 콘솔창에 출력합니다.
        /// </summary>
        public void Present()
        {
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i].Present();
            }
        }
        /// <summary>
        /// 이 인스턴스가 가리키고 있는 위치의 내용을 지웁니다.
        /// </summary>
        public void Depresent()
        {
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i].Depresent();
            }
        }
        string[] SplitText(string text)
        {
            return Util.LineRegex.Split(text);
        }
    }
}
