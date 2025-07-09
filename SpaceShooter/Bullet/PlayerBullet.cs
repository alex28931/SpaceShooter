using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class PlayerBullet : Bullet
    {
        //Variables
        public PlayerBullet() : base("blueLaser")
        {
            BulletType = BulletType.PlayerBullet;
            RigidBody.Type = RigidBodyType.PlayerBullet;
            RigidBody.Collider = ColliderFactory.CreateBoxColliderFor(this);
            RigidBody.AddCollisionType((uint)RigidBodyType.Enemy | (uint)RigidBodyType.EnemyBullet);
            Damage = 50;
        }
        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X - HalfWidth >= Game.Window.Width || Position.Y + HalfHeight < 0 || Position.Y - HalfHeight >= Game.Window.Height) 
                {
                    BulletMngr.RestoreBullet(this);
                }
            }
        }
        public override void OnCollide(GameObject other)
        {
            if (other.RigidBody.Type==RigidBodyType.Enemy)
            {
                if (((Enemy)other).Energy <= Damage)
                {
                    owner.AddScore(((Enemy)other).PointForDeath);
                }
                ((Enemy)other).AddDamage(Damage);
            }
            BulletMngr.RestoreBullet(this);
        }
    }
}
