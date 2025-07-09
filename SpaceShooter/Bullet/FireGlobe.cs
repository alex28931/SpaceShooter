using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class FireGlobe : EnemyBullet
    {
        protected float rotationSpeed;
        protected float accumulator;
        public FireGlobe() : base("fireGlobe")
        {
            BulletType = BulletType.FireGlobe;
            RigidBody.Collider = ColliderFactory.CreateCircleFor(this);
            rotationSpeed = 2.0f;
        }
        public override void Update()
        {
            base.Update();
            if (IsActive)
            {
                sprite.Rotation -= MathHelper.DegreesToRadians(rotationSpeed);
                accumulator += Game.DeltaTime*10;
                RigidBody.Velocity.Y = (float)Math.Cos(accumulator)*800f;
            }
        }
        public override void Reset()
        {
            base.Reset();
            accumulator = 0.0f;
        }
    }
}  