using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    static class BulletMngr
    {
        private static Queue<Bullet>[] bullets;
        public static void Init()
        {
            bullets = new Queue<Bullet>[(int)BulletType.LAST];
            int maxEnemyBullet = 16;
            int maxPlayerBullet = 30;
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new Queue<Bullet>(maxPlayerBullet);
                switch ((BulletType)i)
                {
                    case (BulletType.PlayerBullet):
                        for (int q = 0; q < maxPlayerBullet; q++)
                        {
                            bullets[i].Enqueue(new PlayerBullet());
                        }
                        break;
                    case (BulletType.PurpleLaser):
                        for (int q = 0; q < maxEnemyBullet; q++)
                        {
                            bullets[i].Enqueue(new PurpleLaser());
                        }
                        break;
                    case (BulletType.FireGlobe):
                        for (int q = 0; q < maxEnemyBullet; q++)
                        {
                            bullets[i].Enqueue(new FireGlobe());
                        }
                        break;
                }
            }
        }
        public static Bullet GetBullet(BulletType type)
        {
            int index = (int)type;
            if (bullets[index].Count > 0)
            {
                Bullet b = bullets[index].Dequeue();
                b.Reset();
                return b;
            }
            return null;
        }
        public static void RestoreBullet(Bullet b)
        {
            b.IsActive = false;
            int index = (int)b.BulletType;
            bullets[index].Enqueue(b);
        }
        public static void ClearAll()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Clear();
            }
        }
    }
}
