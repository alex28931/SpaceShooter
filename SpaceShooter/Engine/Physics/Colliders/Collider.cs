using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    abstract class Collider
    {
        public RigidBody RigidBody;
        public Vector2 OffSet;
        public Vector2 Position { get { return RigidBody.Position + OffSet; } }

        public Collider(RigidBody owner)
        {
            RigidBody = owner;
            OffSet = Vector2.Zero;
        }

        public abstract bool Collides(Collider collider);
        public abstract bool Collides(CircleCollider collider);
        public abstract bool Collides(BoxCollider collider);
        public abstract bool Collides(CompoundCollider collider);
        public abstract bool Contain(Vector2 point);
    }
}
