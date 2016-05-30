using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    public class ConsoleLoop
    {
        bool isRun;
        Action loop;

        public bool IsRun
        {
            get
            {
                return isRun;
            }
        }
        public ConsoleLoop(Action loop)
        {
            this.loop = loop;
        }
        public void Run()
        {
            this.isRun = true;
            while (isRun)
            {
                loop();
            }
        }
        public void Stop()
        {
            isRun = false;
        }
    }
}
