using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    static class SpawnMngr
    {
        private static Queue<Enemy>[] enemies;
        private static float nextSpawn;
        public static void Init()
        {
            enemies = new Queue<Enemy>[(int)EnemyType.LAST];
            int totEnemy = 10;

            for (int i = 0; i < (int)EnemyType.LAST; i++)
            {
                enemies[i] = new Queue<Enemy>();
                for (int j = 0; j < totEnemy; j++)
                {
                    if (i == (int)EnemyType.GreenShip)
                    {
                        enemies[i].Enqueue(new Greenship());
                    }
                    if (i == (int)EnemyType.BigEnemy)
                    {
                        enemies[i].Enqueue(new BigEnemy());
                    }
                }
            }
            nextSpawn = RandomGenerator.RandomInt(1, 3);
        }
        public static void Update()
        {
            nextSpawn -= Game.Window.DeltaTime;
            if (nextSpawn <= 0)
            {
                nextSpawn = RandomGenerator.RandomInt(3, 5);
                SpawnEnemy();
            }
        }
        public static void SpawnEnemy()
        {
            int randomType = RandomGenerator.RandomInt(0, (int)EnemyType.LAST);
            if (enemies[randomType].Count > 0)
            {
                Enemy e = enemies[randomType].Dequeue();
                e.IsActive = true;
                e.Position = new Vector2(Game.Window.Width + e.HalfWidth, RandomGenerator.RandomInt((int)e.HalfHeight, Game.Window.Height - (int)e.HalfHeight));
            }
        }
        public static void RestoreEnemy(Enemy e)
        {
            enemies[(int)e.EnemyType].Enqueue(e);
            e.IsActive = false;
        }
        public static void ClearAll()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Clear();
            }
        }
    }
}
