using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;
namespace SpaceShooter
{
    static class DebugMngr
    {
        static List<Collider> items;
        static List<Sprite> sprites;
        static Vector4 greenColor;
        static Texture circleTexture;
        static DebugMngr()
        {
            items = new List<Collider>();
            sprites = new List<Sprite>();
            greenColor = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
            circleTexture = GfxMngr.GetTexture("circle");
        }
        public static void AddItem(Collider c)
        {
            items.Add(c);
            if (c is BoxCollider)
            {
                Sprite s = new Sprite(((BoxCollider)c).Width, ((BoxCollider)c).Height);
                s.pivot = new Vector2(s.Width * 0.5f, s.Height * 0.5f);
                sprites.Add(s);
            }
            else
            {
                Sprite s = new Sprite(((CircleCollider)c).Radius * 2.0f, ((CircleCollider)c).Radius * 2.0f);
                s.pivot = new Vector2(s.Width * 0.5f, s.Height * 0.5f);
                sprites.Add(s);
            }
        }
        public static void Draw()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].RigidBody.IsActive)
                {
                    sprites[i].position = items[i].Position;
                    if (items[i] is BoxCollider)
                    {
                        sprites[i].DrawWireframe(greenColor);
                    }
                    else
                    {
                        sprites[i].DrawTexture(circleTexture);
                    }
                }
            }
        }
        public static void ClearAll()
        {
            items.Clear();
            sprites.Clear();
        }
    }
}
