using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    enum BulletType { PlayerBullet, PurpleLaser, FireGlobe, LAST }
    abstract class Bullet : GameObject
    {
        //Variables
        protected Actor owner;
        public BulletType BulletType { get; protected set; }
        public float Damage { get; protected set; }
        public Bullet(string textureName,int spriteWidth=0, int spriteHeight=0, int offsetX=0, int offsetY=0) : base(textureName, spriteWidth, spriteHeight, offsetX, offsetY)
        {
            RigidBody = new RigidBody(this);
            UpdateMngr.AddItem(this);
            DrawMgr.AddItem(this);
        }
        public virtual void Shoot(Vector2 shootPos, Vector2 shootVel, float shootAngle)
        {
            Position = shootPos;
            RigidBody.Velocity = shootVel;
            sprite.Rotation = shootAngle;
        }
        public virtual void SetOwner(Actor p)
        {
            owner = p;
        }
        public virtual void Reset()
        {
            IsActive = true;
        }
    }
}
