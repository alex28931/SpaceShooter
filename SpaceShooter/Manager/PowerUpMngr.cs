using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    static class PowerUpMngr
    {
        static List<PowerUp> items;
        static float nextSpawn;

        public static void Init()
        {
            items = new List<PowerUp>();
            for (int i = 0; i < 5; i++)
            {
                items.Add(new EnergyPowerUp());
            }
            for (int i = 0; i < 2; i++)
            {
                items.Add(new TripleShoot());
            }
        }
        public static void Update()
        {
            nextSpawn -= Game.DeltaTime;
            if (nextSpawn <= 0)
            {
                Spawn();
                nextSpawn = RandomGenerator.RandomFloat() * 8 + 3;
            }
        }
        public static void Spawn()
        {
            if (items.Count > 0)
            {
                int randomIndex = RandomGenerator.RandomInt(0, items.Count);
                PowerUp pu = items[randomIndex];
                items.RemoveAt(randomIndex);
                pu.Position = new Vector2(Game.Window.Width + pu.HalfWidth, RandomGenerator.RandomInt((int)pu.HalfHeight, Game.Window.Height - (int)pu.HalfHeight));
                pu.IsActive = true;
            }
        }
        public static void Restore(PowerUp pu)
        {
            pu.IsActive = false;
            items.Add(pu);
        }
        public static void ClearAll()
        {
            items.Clear();
        }
    }
}
