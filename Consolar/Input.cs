using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    public class InputManager
    {
        readonly ConsoleKeyInfo zero = new ConsoleKeyInfo('\0', 0, false, false, false);
        ConsoleKeyInfo keyInfo;
        public void KeyCheck()
        {
            if (Console.KeyAvailable)
            {
                this.keyInfo = Console.ReadKey(true);
                // 버퍼 날리기
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
            else
            {
                this.keyInfo = this.zero;
            }
        }
        void OnKeyInput(ConsoleKeyInfo keyInfo)
        {
            if (KeyInput != null)
            {
                KeyInput(this, new InputEventArgs(keyInfo));
            }
        }
        event EventHandler<InputEventArgs> KeyInput;
        public ConsoleKeyInfo KeyInfo
        {
            get
            {
                return keyInfo;
            }
        }
    }
    public class InputEventArgs : EventArgs
    {
        public InputEventArgs(ConsoleKeyInfo keyInfo)
        {
            this.KeyInfo = keyInfo;
        }
        public ConsoleKeyInfo KeyInfo
        {
            get;
        }
    }
}
