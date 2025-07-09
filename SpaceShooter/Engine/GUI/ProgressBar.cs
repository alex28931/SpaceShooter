using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;

namespace SpaceShooter
{
    class ProgressBar : GameObject
    {
        protected Vector2 offset;
        protected Sprite barSprite;
        protected Texture barTexture;
        protected int barWidth;
        public override Vector2 Position { get { return base.Position; } set { base.Position = value; barSprite.position = value + offset; } }
        public ProgressBar(string frameName, string barName, Vector2 inneroffset) : base(frameName)
        {
            barTexture = GfxMngr.GetTexture(barName);
            barSprite = new Sprite(barTexture.Width, barTexture.Height);
            offset = inneroffset;
            barSprite.pivot = Vector2.Zero;
            sprite.pivot = Vector2.Zero;

            barWidth = barTexture.Width;
            IsActive = true;
            Scale(1);

            DrawMgr.AddItem(this);
        }
        public override void Draw()
        {
            if (IsActive)
            {
                base.Draw();
                barSprite.DrawTexture(barTexture, 0, 0, barWidth, (int)barSprite.Height);
            }
        }
        public virtual void Scale(float scale)
        {
            scale = MathHelper.Clamp(scale, 0, 1);
            barSprite.scale.X = scale;
            //barWidth = (int)(scale * barSprite.Width);
            barSprite.SetMultiplyTint((1 - scale) * 50, scale * 2, scale, 1);
        }
    }
}
