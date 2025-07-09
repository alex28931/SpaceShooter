using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class Background : I_Drawable, I_Updatable
    {
        private Sprite head;
        private Sprite tail;
        private Texture texture;
        private float speed;
        private Vector2 velocity;

        public Vector2 Position { get { return head.position; } set { head.position = value; } }

        public Background()
        {
            texture = GfxMngr.GetTexture("backGround");
            head = new Sprite(texture.Width, texture.Height);
            speed = 800.0f;
            velocity.X = speed;

            tail = new Sprite(texture.Width, texture.Height);
            tail.position.X = head.Width;
            UpdateMngr.AddItem(this);
            DrawMgr.AddItem(this);
        }
        public void Draw()
        {
            head.DrawTexture(texture);
            tail.DrawTexture(texture);
        }
        public void Update()
        {
            head.position -= velocity * Game.DeltaTime;
            if (head.position.X + head.Width < 0)
            {
                head.position.X = 0.0f;
            }
            tail.position.X = head.position.X + head.Width;
        }
    }
}
