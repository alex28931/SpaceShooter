using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class TextObject
    {
        protected List<TextChar> sprites;
        protected string text;
        protected Font font;
        protected bool isactive;
        protected Vector2 position;
        protected int horizontalSpace;

        public bool IsActive { get { return isactive; } set { isactive = value; ChangeTextStatus(); } }
        public string Text { get { return text; } set { SetText(value); } }
        public TextObject(Vector2 position, string fontName, string text = "", int horizontalSpace = 0)
        {
            this.horizontalSpace = horizontalSpace;
            this.position = position;
            font = FontMngr.GetFont(fontName);
            isactive = true;
            sprites = new List<TextChar>();
            Text = text;
        }
        protected void ChangeTextStatus()
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].IsActive = isactive;
            }
        }
        public void SetText(string newText)
        {
            if(newText != text)
            {
                text = newText;
                int charX = (int)position.X;
                int charY = (int)position.Y;
                for (int i = 0; i < text.Length; i++)
                {
                    if (i >= sprites.Count)
                    {
                        TextChar tc = new TextChar(new Vector2(charX, charY), text[i], font);
                        tc.IsActive = isactive;
                        sprites.Add(tc);
                    }
                    else if(text[i] != sprites[i].Character)
                    {
                        sprites[i].Character = text[i];
                    }
                    charX += (int)sprites[i].HalfWidth * 2 + horizontalSpace;
                }
                if (sprites.Count > text.Length)
                {
                    int count = sprites.Count - text.Length;
                    for (int i = text.Length; i < sprites.Count; i++)
                    {
                        sprites[i].Destroy();
                    }
                    sprites.RemoveRange(text.Length, sprites.Count);
                }
            }
        }
    }
}
