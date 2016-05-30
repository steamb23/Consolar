using System;
using System.Threading;

namespace SteamB23.Consolar.UI
{
    public class Option
    {
        TextLine textLine;
        ConsoleColor foregroundColor;
        ConsoleColor backgroundColor;
        ConsoleColor selectedForegroundColor;
        ConsoleColor selectedBackgroundColor;

        InputManager inputMgr = new InputManager();

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

        public ConsoleColor SelectedForegroundColor
        {
            get
            {
                return selectedForegroundColor;
            }

            set
            {
                this.selectedForegroundColor = value;
            }
        }

        public ConsoleColor SelectedBackgroundColor
        {
            get
            {
                return selectedBackgroundColor;
            }

            set
            {
                this.selectedBackgroundColor = value;
            }
        }

        public Option(string[] elements, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor selectedForegroundColor = ConsoleColor.White, ConsoleColor selectedBackgroundColor = ConsoleColor.Black, bool isRight = false)
        {
            textLine = new TextLine(elements, left, top, length, foregroundColor, backgroundColor, isRight);
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
            this.SelectedForegroundColor = selectedForegroundColor;
            this.SelectedBackgroundColor = selectedBackgroundColor;
        }
        public int GetSelect()
        {
            int currentSelectedNumber = 0;
            ConsoleText item;
            item = textLine.ConsoleTexts[currentSelectedNumber];
            item.ForegroundColor = this.SelectedForegroundColor;
            item.BackgroundColor = this.SelectedBackgroundColor;
            textLine.Present();
            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
            while (true)
            {
                inputMgr.KeyCheck();

                switch (inputMgr.KeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentSelectedNumber > 0)
                        {
                            item = textLine.ConsoleTexts[currentSelectedNumber--];
                            item.ForegroundColor = this.ForegroundColor;
                            item.BackgroundColor = this.BackgroundColor;
                            item.Present();

                            item = textLine.ConsoleTexts[currentSelectedNumber];
                            item.ForegroundColor = this.SelectedForegroundColor;
                            item.BackgroundColor = this.SelectedBackgroundColor;
                            item.Present();
                            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelectedNumber + 1 < textLine.Row)
                        {
                            item = textLine.ConsoleTexts[currentSelectedNumber++];
                            item.ForegroundColor = this.ForegroundColor;
                            item.BackgroundColor = this.BackgroundColor;
                            item.Present();

                            item = textLine.ConsoleTexts[currentSelectedNumber];
                            item.ForegroundColor = this.SelectedForegroundColor;
                            item.BackgroundColor = this.SelectedBackgroundColor;
                            item.Present();
                            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
                        }
                        break;
                    case ConsoleKey.Enter:
                        textLine.ForegroundColor = this.ForegroundColor;
                        textLine.BackgroundColor = this.BackgroundColor;
                        textLine.Depresent();
                        return currentSelectedNumber;
                }
                Thread.Sleep(1);
            }
        }
    }
}
