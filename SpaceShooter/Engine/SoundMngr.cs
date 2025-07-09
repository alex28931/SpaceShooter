using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Audio;

namespace SpaceShooter
{
    static class SoundMngr
    {
        private static Dictionary<string, AudioClip> Clips;
        public static void Init()
        {
            Clips = new Dictionary<string, AudioClip>();
        }
        public static void AddClip(string key, string ClipPath)
        {
            AudioClip c = new AudioClip(ClipPath);
            if (c != null)
                Clips.Add(key, c);
        }
        public static AudioClip GetClip(string key)
        {
            AudioClip c = null;
            if (Clips.ContainsKey(key))
                return Clips[key];
            return c;
        }
        public static void ClearAll()
        {
            Clips.Clear();
        }
    }
}
