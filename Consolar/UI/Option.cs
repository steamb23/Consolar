using System;
using System.Threading;

namespace SteamB23.Consolar.UI
{
    /// <summary>
    /// 선택지기능을 제공합니다.
    /// </summary>
    public class Option : IPresentable
    {
        TextBox textBox;
        ConsoleColor foregroundColor;
        ConsoleColor backgroundColor;
        ConsoleColor selectedForegroundColor;
        ConsoleColor selectedBackgroundColor;

        InputManager inputMgr = new InputManager();

        /// <summary>
        /// 선택하지 않았을 때의 전경색을 가져오거나 설정합니다.
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
        /// 선택하지 않았을 때의 배경색을 가져오거나 설정합니다.
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
        /// 선택했을 때의 전경색을 가져오거나 설정합니다.
        /// </summary>
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
        /// <summary>
        /// 선택했을 때의 배경색을 가져오거나 설정합니다.
        /// </summary>
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

        /// <summary>
        /// <seealso cref="UI.TextBox"/>의 인스턴스를 가져옵니다.
        /// </summary>
        public TextBox TextBox
        {
            get
            {
                return textBox;
            }
        }

        /// <summary>
        /// 옵션의 원소 배열과 위치, 길이, 색상 등을 사용하여 <see cref="Option"/>클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="elements">옵션의 원소들입니다.</param>
        /// <param name="left">출력할 텍스트의 가로 위치입니다.</param>
        /// <param name="top">출력할 텍스트의 세로 위치입니다.</param>
        /// <param name="length">출력할 텍스트의 최대 길이입니다.</param>
        /// <param name="foregroundColor">선택되지 않은 텍스트의 전경색입니다.</param>
        /// <param name="backgroundColor">선택되지 않은 텍스트의 배경색입니다.</param>
        /// <param name="selectedForegroundColor">선택된 텍스트의 전경색입니다.</param>
        /// <param name="selectedBackgroundColor">선택된 텍스트의 배경색입니다.</param>
        /// <param name="isRight">오른쪽으로 정렬할지 지정합니다.</param>
        public Option(string[] elements, int left, int top, int length, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor selectedForegroundColor = ConsoleColor.Black, ConsoleColor selectedBackgroundColor = ConsoleColor.Gray, bool isRight = false)
        {
            this.textBox = new TextBox(elements, left, top, length, foregroundColor, backgroundColor, isRight);
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
            this.SelectedForegroundColor = selectedForegroundColor;
            this.SelectedBackgroundColor = selectedBackgroundColor;
        }
        /// <summary>
        /// 선택지를 표시한 후 선택된 원소의 번호를 반환합니다.
        /// </summary>
        /// <returns>선택된 원소의 번호</returns>
        public int GetSelect(bool isKeep = false)
        {
            int currentSelectedNumber = 0;
            ConsoleText item = UpdateElementColor(currentSelectedNumber, this.SelectedForegroundColor, this.SelectedBackgroundColor);
            textBox.Present();
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
                        if (currentSelectedNumber + 1 < textBox.Row)
                        {
                            item = UpdateElementColor(currentSelectedNumber++, this.ForegroundColor, this.BackgroundColor);
                            item.Present();
                            item = UpdateElementColor(currentSelectedNumber, this.SelectedForegroundColor, this.SelectedBackgroundColor);
                            item.Present();
                            Console.SetCursorPosition(item.Left + item.asciiLength, item.Top);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (!isKeep)
                        {
                            textBox.ForegroundColor = this.ForegroundColor;
                            textBox.BackgroundColor = this.BackgroundColor;
                            textBox.Depresent();
                        }
                        Console.SetCursorPosition(0, textBox.Top+textBox.ConsoleTexts.Length);
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
            ConsoleText consoleText = textBox.ConsoleTexts[elementNumber];
            consoleText.ForegroundColor = foregroundColor;
            consoleText.BackgroundColor = backgroundColor;
            return consoleText;
        }
        bool InputNumber(int number, ref int currentSelectedNumber)
        {
            bool ok = number < textBox.Row;
            if (ok)
            {
                currentSelectedNumber = number;
            }
            return ok;
        }
        /// <summary>
        /// 이 인스턴스의 내용을 콘솔창에 출력합니다.
        /// </summary>
        public void Present()
        {
            textBox.Present();
        }

        /// <summary>
        /// 이 인스턴스가 가리키고 있는 위치의 내용을 지웁니다.
        /// </summary>
        public void Depresent()
        {
            textBox.Depresent();
        }
    }
}
