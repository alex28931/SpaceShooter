using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class TextChar : GameObject
    {
        protected Font font;
        protected char character;
        public char Character { get { return character; } set { character = value;ComputOffset(); } }
        public TextChar(Vector2 spritePosition, char character, Font f) : base(f.TextureName, spriteWidth: f.CharWidth, spriteHeight: f.CharHeight)
        {
            sprite.position = spritePosition;
            sprite.pivot = Vector2.Zero;
            font = f;
            Character = character;
            IsActive = true;
            DrawMgr.AddItem(this);   
        }
        protected void ComputOffset()
        {
            Vector2 textureOffset = font.GetOffset(character);
            textureOffsetX = (int)textureOffset.X;
            textureOffsetY = (int)textureOffset.Y;
        }
        public override void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture, textureOffsetX, textureOffsetY, (int)sprite.Width, (int)sprite.Height);
            }
        }
    }
}
