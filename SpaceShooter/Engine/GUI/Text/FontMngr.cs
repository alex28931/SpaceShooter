using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class FontMngr
    {
        private static Dictionary<string, Font> fonts;
        private static Font defaultFont;
        static FontMngr()
        {
            fonts = new Dictionary<string, Font>();
        }
        public static void AddFont(string fontName, string texturePath, int numcol, int charWidth, int charHeight,int firstCharacterACIIvalue)
        {
            Font f = new Font(fontName, texturePath, numcol, charWidth, charHeight, firstCharacterACIIvalue);
            if (!fonts.ContainsKey(fontName))
            {
                fonts[fontName] = f;
            }
            if (defaultFont == null)
            {
                defaultFont = f;
            }
        }
        public static Font GetFont(string fontName)
        {
            if (fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }
            else
            {
                return defaultFont;
            }
        }
        public static void ClearAll()
        {
            fonts.Clear();
            defaultFont = null;
        }
    }
}
