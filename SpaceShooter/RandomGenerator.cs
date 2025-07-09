using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class RandomGenerator
    {
        private static Random random;
        static RandomGenerator()
        {
            random = new Random();
        }
        public static int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
        public static float RandomFloat()
        {
            return (float)random.NextDouble();
        }
    }
}
