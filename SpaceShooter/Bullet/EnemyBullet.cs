using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class EnemyBullet : Bullet
    {
        public EnemyBullet(string textureName, int spriteWidth = 0, int spriteHeight = 0, int offsetX = 0, int offsetY = 0) : base(textureName, spriteWidth, spriteHeight, offsetX, offsetY)
        {
            BulletType = BulletType.PurpleLaser;
            RigidBody.Type = RigidBodyType.EnemyBullet;
            RigidBody.AddCollisionType((uint)RigidBodyType.Player | (uint)RigidBodyType.PlayerBullet);
            Damage = 25.0f;
        }

        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + HalfWidth < 0)
                {
                    BulletMngr.RestoreBullet(this);
                }
            }
        }
        public override void OnCollide(GameObject other)
        {
            if (other.RigidBody.Type == RigidBodyType.Player)
            {
                ((Player)other).AddDamage(Damage);
            }
            BulletMngr.RestoreBullet(this);
        }
    }
}
