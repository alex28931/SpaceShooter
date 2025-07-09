using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class PurpleLaser : EnemyBullet
    {
        public PurpleLaser() : base("purpleLaser", 74, 46, 156, 227)
        {
            BulletType = BulletType.PurpleLaser;
            RigidBody.Collider = ColliderFactory.CreateBoxColliderFor(this);
        }
    }
}
