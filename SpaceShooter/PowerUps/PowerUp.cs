using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    abstract class PowerUp : GameObject
    {
        protected Player attachedPlayer;
        public PowerUp(string textureName) : base(textureName)
        {
            RigidBody = new RigidBody(this);
            RigidBody.Type = RigidBodyType.PowerUp;
            RigidBody.Collider = ColliderFactory.CreateCircleFor(this,true);
            RigidBody.AddCollisionType(RigidBodyType.Player);
            Speed = -300.0f;
            RigidBody.Velocity = new Vector2(Speed, 0.0f);
            UpdateMngr.AddItem(this);
            DrawMgr.AddItem(this);
        }

        public override void Update()
        {
            if (IsActive)
            {
                if (Position.X + HalfWidth < 0)
                {
                    PowerUpMngr.Restore(this);
                }
            }
        }
        public virtual void OnAttach(Player p)
        {
            attachedPlayer = p;
            IsActive = false;
        }
        public virtual void OnDetach()
        {
            attachedPlayer = null;
            PowerUpMngr.Restore(this);
        }
        public override void OnCollide(GameObject other)
        {
            OnAttach((Player)other);
        }
    }
}
