using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    enum RigidBodyType { Player = 1, PlayerBullet = 2, Enemy = 4, EnemyBullet = 8, PowerUp = 16 }
    class RigidBody
    {
        protected uint collisionMask;

        public GameObject GameObject;
        public Collider Collider;
        public Vector2 Velocity;
        public RigidBodyType Type;

        public bool IsGravityAffected;
        public bool IsCollisionAffected = true;
        public bool IsActive { get { return GameObject.IsActive; } }
        public Vector2 Position { get { return GameObject.Position; } }
        public RigidBody(GameObject owner)
        {
            GameObject = owner;
            PhysicsMngr.AddITem(this);
        }
        public void Update()
        {
            GameObject.Position += Velocity * Game.DeltaTime;
        }
        public bool Collides(RigidBody other)
        {
             return Collider.Collides(other.Collider);
        }
        public void AddCollisionType(RigidBodyType type)
        {
            collisionMask |= (uint)type;
        }
        public void AddCollisionType(uint type)
        {
            collisionMask |= type;
        }
        public bool CollisionTypeMatches(RigidBodyType type)
        {
            return (collisionMask & (uint)type) != 0;
        }
        public void Destroy()
        {
            GameObject = null;
            if (Collider != null)
            {
                Collider.RigidBody = null;
                Collider = null;
            }
            PhysicsMngr.RemoveITem(this);
        }
    }
}
