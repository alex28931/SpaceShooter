using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    enum EnemyType { GreenShip, BigEnemy, LAST }
    abstract class Enemy : Actor
    {
        //Variables
        private float timerForShoot;
        public EnemyType EnemyType { get; protected set; }
        public int PointForDeath { get; protected set; }
        public Enemy(string textureName) : base(textureName)
        {
            sprite.FlipX = true;
            timerForShoot = RandomGenerator.RandomInt(1, 2);
            RigidBody.Type = RigidBodyType.Enemy;
            int r = RandomGenerator.RandomInt(0, 2);
            if (r == 0)
            {
                bulletType = BulletType.PurpleLaser;
            }
            else
            {
                bulletType = BulletType.FireGlobe;
            }
            shootSound = SoundMngr.GetClip("enemyShoot");
        }
        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + HalfWidth < 0)
                {
                    SpawnMngr.RestoreEnemy(this);
                }
                else
                {
                    timerForShoot -= Game.Window.DeltaTime;
                    if (timerForShoot <= 0)
                    {
                        timerForShoot = RandomGenerator.RandomFloat() * 2 + 1;
                        Shoot();
                    }
                }
            }
        }
        public override void OnDie()
        {
            SpawnMngr.RestoreEnemy(this);
        }
    }
}
