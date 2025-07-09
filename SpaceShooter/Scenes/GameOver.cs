using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Audio;

namespace SpaceShooter
{
    class GameOver : Title
    {
        public KeyCode replayKey;
        public GameOver() : base("gameOver")
        {
            escKey = KeyCode.N;
            replayKey = KeyCode.Y;
        }
        public override void Start()
        {
            base.Start();
        }
        public override Scene OnExit()
        {
            GfxMngr.ClearAll();
            return base.OnExit();
        }
        public override void Draw()
        {
            Sprite.DrawTexture(Texture);
        }

        public override void input()
        {
            if (Game.Window.GetKey(escKey))
            {
                IsPlaying = false;
                NextScene = null;
            }
            else if (Game.Window.GetKey(replayKey))
            {
                IsPlaying = false;
            }
        }

        public override void LoadAssets()
        {
            GfxMngr.AddTexture(TextureName, "Assets/gameOverBg.png");
        }
    }
}
