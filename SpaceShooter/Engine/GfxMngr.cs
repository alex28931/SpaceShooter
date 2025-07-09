using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    static class GfxMngr
    {
        private static Dictionary<string, Texture> textures;
        public static void Init()
        {
            textures = new Dictionary<string, Texture>();
        }
        public static void AddTexture(string key, string textturePath)
        {
            Texture t = new Texture(textturePath);
            if (t != null)
                textures.Add(key, t);
        }
        public static Texture GetTexture(string key)
        {
            Texture texture = new Texture();
            if (textures.ContainsKey(key))
                return textures[key];
            return texture;
        }
        public static void ClearAll()
        {
            textures.Clear();
        }
    }
}
