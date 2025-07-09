using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
namespace SpaceShooter
{
    static class Game
    {
        public static Window Window;
        public static Scene Currentscene;
        private static KeyboardCtrl keyboardCtrl;
        private static List<Controller> controllers;
        public static int Numcontrollers { get { return controllers.Count; } }
        

        public static float DeltaTime { get { return Window.DeltaTime; } }
        public static float ScreenCenterX { get { return Window.Width * 0.5f; } }
        public static float ScreenCenterY { get { return Window.Height * 0.5f; } }

        public static void Init()
        {
            Window = new Window(1280, 720, "SpaceShooter");
            Window.SetMouseVisible(false);

            keyboardCtrl = new KeyboardCtrl(0);
            controllers = new List<Controller>();
            string[] joystics = Window.Joysticks;
            for (int i = 0; i < joystics.Length; i++)
            {
                Console.WriteLine(joystics[i]);
                if(joystics[i]!= null && joystics[i] != "Unmapped Controller")
                {
                    controllers.Add(new JoypadCtrl(i));
                }
            }

            Title title = new Title();
            PlayScene playScene = new PlayScene();
            GameOver gameOver = new GameOver();
            Currentscene = title;
            title.NextScene = playScene;
            playScene.NextScene = gameOver;
            gameOver.NextScene = playScene;
        }
        public static Controller GetController(int ctrlIndex)
        {
            Controller ctrl = keyboardCtrl;
            if (ctrlIndex < controllers.Count)
            {
                ctrl = controllers[ctrlIndex];
            }
            return ctrl;
        }
        
        public static void Play()
        {
            Currentscene.Start();
            while (Window.IsOpened)
            {
                if (Window.GetKey(KeyCode.Esc))
                {
                    return;
                }
                if (!Currentscene.IsPlaying)
                {
                    Scene nextScene = Currentscene.OnExit();
                    if (nextScene != null)
                    {
                        Currentscene = nextScene;
                    }
                    else
                    {
                        return;
                    }
                    Currentscene.Start();
                }
                Currentscene.input();
                Currentscene.Update();
                Currentscene.Draw();
                Window.Update();
            }
        }
    }
}
