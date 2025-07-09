using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Audio;

namespace SpaceShooter
{
    enum WeaponType { Default, Tripleshoot}
    abstract class Actor : GameObject
    {
        //Variables
        protected int score;
        protected WeaponType weaponType = WeaponType.Default;
        protected Vector2 shootOffset;
        protected float shootVel;
        protected float tripleShootAngle;
        protected BulletType bulletType;
        protected AudioSource soundEmitter;
        protected AudioClip shootSound;
        public float Energy { get; protected set; }
        public float MaxEnergy { get; protected set; }

        public Actor(string textureName): base(textureName)
        {
            RigidBody = new RigidBody(this);
            soundEmitter = new AudioSource();
            UpdateMngr.AddItem(this);
            DrawMgr.AddItem(this);
        }
        public virtual void Shoot()
        {
            Bullet b = BulletMngr.GetBullet(bulletType);
            if (b != null)
            {
                //b.RigidBody.Velocity = new Vector2(b.Speed, 0.0f);

                soundEmitter.Play(shootSound);
                b.Shoot(Position + shootOffset, Forward * shootVel, sprite.Rotation);
                b.SetOwner(this);
            }
        }
        public virtual void AddDamage(float dmg)
        {
            Energy -= dmg;
            if (Energy <= 0)
            {
                OnDie();
            }
        }
        public abstract void OnDie();
        public virtual void ResetEnergy()
        {
            Energy = MaxEnergy;
        }
        public virtual void TripleShoot()
        {
            float angle;
            Vector2 direction;
            for (int i = 0; i < 3; i++)
            {
                Bullet b = BulletMngr.GetBullet(bulletType);
                if(b != null)
                {
                    soundEmitter.Play(shootSound);
                    angle = tripleShootAngle * (1 - i) + sprite.Rotation;
                    direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                    direction.Normalize();
                    b.Shoot(Position + shootOffset, direction * shootVel, angle);
                    b.SetOwner(this);
                }
            }
        }
        public virtual void ChangeWeaponType(WeaponType type)
        {
            weaponType = type;
        }
        public virtual void AddScore(int point)
        {
            score += point;
        }
    }
}
