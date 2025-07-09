using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class CircleCollider : Collider
    {
        public float Radius;

        public CircleCollider(RigidBody rigidbody, float radius) : base(rigidbody)
        {
            Radius = radius;
            //DebugMngr.AddItem(this);
        }
        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }
        // Circle - Circle Collision
        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.Position - Position;
            return dist.LengthSquared <= Math.Pow(other.Radius + Radius,2);
        }
        public override bool Collides(BoxCollider other)
        {
            return other.Collides(this);
        }
        public override bool Collides(CompoundCollider other)
        {
            return other.Collides(this);
        }
        public override bool Contain(Vector2 point)
        {
            Vector2 dist = point - Position;
            return dist.LengthSquared <= (Radius * Radius);
        }
    }
}
