using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.Consolar
{
    public class SceneManager
    {
        Scene currentScene;
        Scene nextScene;

        bool isSceneRun = false;

        public Scene CurrentScene
        {
            get
            {
                return currentScene;
            }
        }
        public Scene NextScene
        {
            get
            {
                return nextScene;
            }

            set
            {
                this.nextScene = value;
            }
        }
        public void ChangeScene()
        {
            if (!isSceneRun)
            {
                while (nextScene != null)
                {
                    currentScene = nextScene;
                    nextScene = null;
                    CurrentScene.Run();
                }
            }
        }
    }
}
