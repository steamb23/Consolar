using System;

namespace SteamB23.Consolar
{
    /// <summary>
    /// 구조화된 루프를 지원합니다.
    /// </summary>
    public class ConsoleLoop
    {
        bool isRun;
        Action loop;

        /// <summary>
        /// 현재 루프의 상태를 가져옵니다.
        /// </summary>
        public bool IsRun
        {
            get
            {
                return isRun;
            }
        }
        /// <summary>
        /// 루프에서 돌아갈 동작을 사용하여 <see cref="ConsoleLoop"/> 클래스의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="loop"></param>
        public ConsoleLoop(Action loop)
        {
            this.loop = loop;
        }
        /// <summary>
        /// 루프를 실행시킵니다.
        /// </summary>
        public void Run()
        {
            this.isRun = true;
            while (isRun)
            {
                loop();
            }
        }
        /// <summary>
        /// 루프를 정지시킵니다.
        /// </summary>
        public void Stop()
        {
            isRun = false;
        }
    }
}
