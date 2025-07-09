using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using Aiv.Audio;
using OpenTK;

namespace SpaceShooter
{
    class PlayScene : Scene
    {
        public Background Background;
        public List<Player> Players;
        public override void Start()
        {
            GfxMngr.Init();
            SoundMngr.Init();
            LoadAssets();
            LoadClips();
            Background = new Background();
            PowerUpMngr.Init();
            BulletMngr.Init();
            SpawnMngr.Init();
            Players = new List<Player>();
            for (int i = 0; i <= Game.Numcontrollers; i++)
            {
                Players.Add(new Player(Game.GetController(i), i));
            }
            base.Start();
        }
        public override Scene OnExit()
        {

            Players.Clear();
            Background = null;
            GfxMngr.ClearAll();
            SoundMngr.ClearAll();
            PowerUpMngr.ClearAll();
            BulletMngr.ClearAll();
            SpawnMngr.ClearAll();
            PhysicsMngr.ClearAll();
            UpdateMngr.ClearAll();
            DrawMgr.ClearAll();
            FontMngr.ClearAll();
            //DebugMngr.ClearAll();
            return base.OnExit();
        }
        public override void LoadClips()
        {
            SoundMngr.AddClip("playerShoot", "Sounds/player_laser.wav");
            SoundMngr.AddClip("enemyShoot", "Sounds/enemy_laser.wav");
        }

        public override void LoadAssets()
        {
            GfxMngr.AddTexture("playerShip", "Assets/player_ship.png");
            GfxMngr.AddTexture("greenShip", "Assets/enemy_ship.png");
            GfxMngr.AddTexture("bigEnemy", "Assets/big_ship.png");
            GfxMngr.AddTexture("blueLaser", "Assets/blueLaser.png");
            GfxMngr.AddTexture("purpleLaser", "Assets/beams.png");
            GfxMngr.AddTexture("backGround", "Assets/spaceBg.png");
            GfxMngr.AddTexture("fireGlobe", "Assets/fireGlobe.png");
            GfxMngr.AddTexture("blueBar", "Assets/loadingBar_bar.png");
            GfxMngr.AddTexture("frameBar", "Assets/loadingBar_frame.png");
            GfxMngr.AddTexture("energy", "Assets/powerUp_battery.png");
            GfxMngr.AddTexture("tripleShoot", "Assets/powerUp_triple.png");
            GfxMngr.AddTexture("circle", "Assets/Circle.png");

            FontMngr.AddFont("stdFont", "Assets/textSheet.png", 15, 20, 20, 32);
            FontMngr.AddFont("comics", "Assets/comics.png", 10, 61, 65, 32);
        }
        public override void input()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Input();
            }
        }
        public virtual void CheckForDeath()
        {
            int counter = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i].IsActive)
                {
                    counter++;
                }
                if (counter == Players.Count)
                {
                    IsPlaying = false;
                }
            }
        }
        public override void Update()
        {
            CheckForDeath();
            PhysicsMngr.Update();
            SpawnMngr.Update();
            PowerUpMngr.Update();
            UpdateMngr.Update();

            PhysicsMngr.CheckCollision();
        }
        public override void Draw()
        {
            
            
            
            DrawMgr.Draw();
            //DebugMngr.Draw();
        }

    }
}
