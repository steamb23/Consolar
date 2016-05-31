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
            ConsoleText item = UpdateElementColor(currentSelectedNumber, this.SelectedForegroundColor, this.SelectedBackgroundColor);
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
                            item = UpdateElementColor(currentSelectedNumber--, this.ForegroundColor, this.BackgroundColor);
                            item.Present();
                            item = UpdateElementColor(currentSelectedNumber, this.SelectedForegroundColor, this.SelectedBackgroundColor);
                            item.Present();
                            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelectedNumber + 1 < textLine.Row)
                        {
                            item = UpdateElementColor(currentSelectedNumber++, this.ForegroundColor, this.BackgroundColor);
                            item.Present();
                            item = UpdateElementColor(currentSelectedNumber, this.SelectedForegroundColor, this.SelectedBackgroundColor);
                            item.Present();
                            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
                        }
                        break;
                    case ConsoleKey.Enter:
                        textLine.ForegroundColor = this.ForegroundColor;
                        textLine.BackgroundColor = this.BackgroundColor;
                        textLine.Depresent();
                        return currentSelectedNumber;
                    case ConsoleKey.F1:
                    case ConsoleKey.D1:
                        if (InputNumber(0, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F2:
                    case ConsoleKey.D2:
                        if (InputNumber(1, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F3:
                    case ConsoleKey.D3:
                        if (InputNumber(2, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F4:
                    case ConsoleKey.D4:
                        if (InputNumber(3, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F5:
                    case ConsoleKey.D5:
                        if (InputNumber(4, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F6:
                    case ConsoleKey.D6:
                        if (InputNumber(5, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F7:
                    case ConsoleKey.D7:
                        if (InputNumber(6, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F8:
                    case ConsoleKey.D8:
                        if (InputNumber(7, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F9:
                    case ConsoleKey.D9:
                        if (InputNumber(8, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F10:
                    case ConsoleKey.D0:
                        if (InputNumber(9, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F11:
                        if (InputNumber(10, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                    case ConsoleKey.F12:
                        if (InputNumber(11, ref currentSelectedNumber))
                            goto case ConsoleKey.Enter;
                        else
                            break;
                }
                Thread.Sleep(1);
            }
        }
        ConsoleText UpdateElementColor(int elementNumber, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ConsoleText consoleText = textLine.ConsoleTexts[elementNumber];
            consoleText.ForegroundColor = foregroundColor;
            consoleText.BackgroundColor = backgroundColor;
            return consoleText;
        }
        bool InputNumber(int number, ref int currentSelectedNumber)
        {
            bool ok = number < textLine.Row;
            if (ok)
            {
                currentSelectedNumber = number;
            }
            return ok;
        }
    }
}
