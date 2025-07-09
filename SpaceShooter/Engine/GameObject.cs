using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    abstract class GameObject : I_Drawable, I_Updatable
    {
        protected Sprite sprite;
        protected Texture texture;
        protected int textureOffsetX;
        protected int textureOffsetY;

        public float Speed { get; protected set; }
        public RigidBody RigidBody;
        public bool IsActive;

        //Properties
        public virtual Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public float HalfWidth { get { return sprite.Width * 0.5f; } }
        public float HalfHeight { get { return sprite.Height * 0.5f; } }
        public Vector2 Forward
        {
            get
            {
                return new Vector2((float)Math.Cos(sprite.Rotation), (float)Math.Sin(sprite.Rotation));
            }
            set
            {
                sprite.Rotation = (float)Math.Atan2(value.Y, value.X);
            }
        }
        public GameObject(string textureName, int spriteWidth=0, int spriteHeight=0, int textureOffsetX=0, int textureOffsetY=0)
        {
            texture = GfxMngr.GetTexture(textureName);
            int spriteW = spriteWidth > 0 ? spriteWidth : texture.Width;
            int spriteH = spriteHeight > 0 ? spriteHeight : texture.Height;
            sprite = new Sprite(spriteW, spriteH);
            sprite.pivot = new Vector2(HalfWidth, HalfHeight);
            this.textureOffsetX = textureOffsetX;
            this.textureOffsetY = textureOffsetY;
        }
        public virtual void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture, textureOffsetX, textureOffsetY, (int)sprite.Width, (int)sprite.Height);
            }
        }
        public virtual void Update()
        {
            //EMPTY METHOD
        }
        public virtual void OnCollide(GameObject other)
        {

        }
        public virtual void Destroy()
        {
            sprite = null;
            texture = null;
            DrawMgr.RemoveItem(this);
            UpdateMngr.RemoveItem(this);
            if (RigidBody != null)
            {
                RigidBody.Destroy();
                RigidBody = null;
            }
        }
    }
}
