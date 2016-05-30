using System;

namespace SteamB23.Consolar.UI
{
    public class TextLine : IPresentable
    {
        ConsoleText[] consoleTexts;
        string originText;
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
        public ConsoleText[] ConsoleTexts
        {
            get
            {
                return this.consoleTexts;
            }
        }
        public int Row
        {
            get
            {
                return consoleTexts.Length;
            }
        }
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

        public int Length
        {
            get
            {
                return consoleTexts[0].Length;
            }
        }
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
        public TextLine(int row, string text, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
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
        public TextLine(int row, string[] texts, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
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
        public TextLine(string[] texts, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            consoleTexts = new ConsoleText[texts.Length];
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i] =
                    i < texts.Length ?
                    new ConsoleText(texts[i], left, top + i, length, foregroundColor, backgroundColor, isRight) :
                    new ConsoleText(left, top + i, length, foregroundColor, backgroundColor, isRight);
            }
        }
        // Empty
        public TextLine(int row, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            consoleTexts = new ConsoleText[row];
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i] =
                    new ConsoleText(left, top + i, length, foregroundColor, backgroundColor, isRight);
            }

        }

        #endregion
        public void Present()
        {
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i].Present();
            }
        }
        public void Depresent()
        {
            for (int i = 0; i < consoleTexts.Length; i++)
            {
                consoleTexts[i].Depresent();
            }
        }
        string[] SplitText(string text)
        {
            return _Util.Line.Split(text);
        }
    }
}
