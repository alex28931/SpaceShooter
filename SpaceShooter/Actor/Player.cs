using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class Player : Actor
    {
        //Variables
        private float rateo;
        private float timer;
        public ProgressBar energyBar { get; protected set; }
        protected TextObject playerName;
        protected TextObject scoreText;
        protected int playerId;
        protected Controller controller;
        public Player(Controller controller, int id=0) : base("playerShip")
        {
            this.controller = controller;
            playerId = id;
            Speed = 350.0f;
            rateo = 0.5f;
            timer = rateo;
            shootOffset = Forward*80;
            shootVel = 600;
            tripleShootAngle = MathHelper.DegreesToRadians(15);
            Position = new Vector2(100.0f, Game.ScreenCenterY + 50 * playerId);
            bulletType = BulletType.PlayerBullet;
            RigidBody.Type = RigidBodyType.Player;
            RigidBody.AddCollisionType(RigidBodyType.Enemy);
            RigidBody.Collider = ColliderFactory.CreateBoxColliderFor(this);
            UpdateMngr.AddItem(this);
            DrawMgr.AddItem(this);
            shootSound = SoundMngr.GetClip("playerShoot");
            IsActive = true;
            MaxEnergy = 100.0f;
            Energy = MaxEnergy;
            energyBar = new ProgressBar("frameBar", "blueBar", new Vector2(4.0f, 4.0f));
            energyBar.Position = new Vector2(60.0f, 50.0f + 100 * playerId);
            Vector2 playerNamePosition = energyBar.Position;
            playerNamePosition.Y -= 20;
            playerName = new TextObject(playerNamePosition, "stdFont", $"Player {playerId + 1}", 5);
            Vector2 scorePosition = energyBar.Position;
            scorePosition.Y += 30;
            scoreText = new TextObject(scorePosition, "stdFont", score.ToString("0000000000"));
        }
        public void Input()
        {
            if (IsActive)
            {
                Vector2 direction = new Vector2(controller.GetHorizontal(), controller.GetVertical());
                if (direction.Length > 1)
                {
                    direction.Normalize();
                }
                RigidBody.Velocity = direction * Speed;
                Forward = controller.GetForward();
                shootOffset = Forward * 80;

                //Input for Shooting;
                if (controller.IsFirePressed() && timer >= rateo)
                {
                    switch (weaponType)
                    {
                        case WeaponType.Default:
                            Shoot();
                            break;
                        case WeaponType.Tripleshoot:
                            TripleShoot();
                            break;
                    }
                    timer = 0.0f;
                }
                timer += Game.Window.DeltaTime;
            }
        }
        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + HalfWidth >= Game.Window.Width)
                {
                    sprite.position.X = Game.Window.Width-HalfWidth;
                }
                else if (Position.X - HalfWidth < 0)
                {
                    sprite.position.X = HalfWidth;
                }
                if(Position.Y + HalfHeight >= Game.Window.Height)
                {
                    sprite.position.Y = Game.Window.Height - HalfHeight;
                }
                else if (Position.Y - HalfHeight < 0)
                {
                    sprite.position.Y = HalfHeight;
                }
            }
        }
        public override void OnDie()
        {
            IsActive = false;
        }
        public override void OnCollide(GameObject other)
        {
            ((Enemy)other).OnDie();
            AddDamage(50);
        }
        public override void AddDamage(float dmg)
        {
            base.AddDamage(dmg);
            energyBar.Scale(Energy / MaxEnergy);
        }
        public override void ResetEnergy()
        {
            base.ResetEnergy();
            energyBar.Scale(Energy / MaxEnergy);
        }
        public override void AddScore(int point)
        {
            base.AddScore(point);
            scoreText.SetText(score.ToString("0000000000"));
        }
    }
}
