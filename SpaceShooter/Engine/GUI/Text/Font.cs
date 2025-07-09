using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;

namespace SpaceShooter
{
    class Font
    {
        protected int numCol;
        protected int firstVal;
        public string TextureName { get; protected set; }
        public Texture Texture { get; protected set; }
        public int CharWidth { get; protected set; }
        public int CharHeight { get; protected set; }
        
        public Font(string textureName, string texturePath, int numCol, int charWidth, int charHeight, int firstCharacterASCIIvalue)
        {
            TextureName = textureName;
            GfxMngr.AddTexture(TextureName, texturePath);
            Texture = GfxMngr.GetTexture(TextureName);
            firstVal = firstCharacterASCIIvalue;
            this.numCol = numCol;
            CharWidth = charWidth;
            CharHeight = charHeight;
        }
        public virtual Vector2 GetOffset(char c)
        {
            int cVal = c;
            int delta = cVal - firstVal;
            return new Vector2((delta % numCol)*CharWidth, (delta / numCol)*CharHeight);
        }
    }
}
