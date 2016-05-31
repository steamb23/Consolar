using System;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 콘솔에서의 입력을 관리합니다.
    /// </summary>
    public class InputManager
    {
        readonly ConsoleKeyInfo zero = new ConsoleKeyInfo('\0', 0, false, false, false);
        ConsoleKeyInfo keyInfo;

        /// <summary>
        /// <see cref="InputManager"/>클래스의 인스턴스를 생성합니다.
        /// </summary>
        public InputManager()
        {
        }
        /// <summary>
        /// 현재 입력된 키를 체크합니다.
        /// </summary>
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
                OnKeyChecked(keyInfo);
            }
            else
            {
                this.keyInfo = this.zero;
            }
        }
        void OnKeyChecked(ConsoleKeyInfo keyInfo)
        {
            if (KeyChecked != null)
            {
                KeyChecked(this, new InputEventArgs(keyInfo));
            }
        }
        /// <summary>
        /// <seealso cref="KeyCheck"/>메서드에서 키 입력을 감지하면 발생합니다.
        /// </summary>
        public event EventHandler<InputEventArgs> KeyChecked;
        /// <summary>
        /// 가장 최근에 감지된 키의 정보를 가져옵니다.
        /// </summary>
        public ConsoleKeyInfo KeyInfo
        {
            get
            {
                return keyInfo;
            }
        }
    }
    /// <summary>
    /// 입력에 대한 이벤트 데이터를 담습니다.
    /// </summary>
    public class InputEventArgs : EventArgs
    {
        /// <summary>
        /// 키의 정보를 이용하여 <see cref="InputEventArgs"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="keyInfo">키의 정보</param>
        public InputEventArgs(ConsoleKeyInfo keyInfo)
        {
            this.KeyInfo = keyInfo;
        }
        /// <summary>
        /// 키 정보를 가져옵니다.
        /// </summary>
        public ConsoleKeyInfo KeyInfo
        {
            get;
        }
    }
}
