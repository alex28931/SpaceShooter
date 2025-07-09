using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class Greenship : Enemy
    {
        public Greenship() : base("greenShip")
        {
            EnemyType = EnemyType.GreenShip;
            shootOffset = new Vector2(-HalfWidth, HalfHeight * 0.5f);
            shootVel = -600;
            Speed = -200.0f;
            RigidBody.Velocity = new Vector2(Speed, 0.0f);
            RigidBody.Collider = ColliderFactory.CreateBoxColliderFor(this);
            MaxEnergy = 100.0f;
            Energy = MaxEnergy;
            PointForDeath = 25;
        }
    }
}
