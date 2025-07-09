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
    class Title : Scene
    {
        public Texture Texture;
        public Sprite Sprite;
        public KeyCode escKey;
        public string TextureName;
        public Title(string textureName="Title")
        {
            escKey = KeyCode.Return;
            TextureName = textureName;
        }
        public override void Start()
        {
            GfxMngr.Init();
            LoadAssets();
            Texture = GfxMngr.GetTexture(TextureName);
            Sprite = new Sprite(Game.Window.Width, Game.Window.Height);
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
            }
        }

        public override void LoadAssets()
        {
            GfxMngr.AddTexture(TextureName, "Assets/aivBG.png");
        }

        public override void LoadClips()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
