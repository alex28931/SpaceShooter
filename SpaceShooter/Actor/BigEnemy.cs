using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class BigEnemy : Enemy
    {
        public BigEnemy() : base("bigEnemy")
        {
            EnemyType = EnemyType.BigEnemy;
            shootOffset = new Vector2(-HalfWidth, HalfHeight * 0.5f);
            shootVel = -600;
            Speed = -200.0f;
            RigidBody.Velocity = new Vector2(Speed, 0.0f);
            MaxEnergy = 100.0f;
            Energy = MaxEnergy;
            PointForDeath = 50;

            RigidBody.Collider = new CompoundCollider(RigidBody, ColliderFactory.CreateBoxColliderFor(this));

            BoxCollider box1 = new BoxCollider(RigidBody, (HalfWidth - 45), (HalfHeight - 15));
            box1.OffSet = new Vector2(35, -10);
            ((CompoundCollider)RigidBody.Collider).AddInnerCollider(box1);

            BoxCollider box2 = new BoxCollider(RigidBody, HalfWidth * 0.5f, HalfHeight / 7);
            box2.OffSet = new Vector2(-90.0f, 60.0f);
            ((CompoundCollider)RigidBody.Collider).AddInnerCollider(box2);

            BoxCollider box3 = new BoxCollider(RigidBody, 40, 12);
            box3.OffSet = new Vector2(-13.0f, 85.0f);
            ((CompoundCollider)RigidBody.Collider).AddInnerCollider(box3);
        }
    }
}
