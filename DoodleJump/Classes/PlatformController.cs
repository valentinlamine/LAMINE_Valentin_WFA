using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public static class PlatformController
    {
        // Lists to store game objects
        public static List<Platform> platforms;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Bonus> bonuses = new List<Bonus>();

        // Initial position of the first platform
        public static int startPlatformPosY = 1000;
        public static int score = 0;

        // Add a platform to the list
        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        // Create a bullet and add it to the list
        public static void CreateBullet(PointF pos)
        {
            var bullet = new Bullet(pos);
            bullets.Add(bullet);
        }

        // Generate the initial sequence of platforms
        public static void GenerateStartSequence(int number = 15)
        {
            Random r = new Random();
            for (int i = 0; i < number; i++)
            {
                Debug.WriteLine(startPlatformPosY);
                int x = r.Next(0, 280);
                int y = r.Next(25, 40);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position);
                platforms.Add(platform);
            }
        }

        // Generate a random platform during gameplay
        public static void GenerateRandomPlatform()
        {
            Debug.WriteLine(startPlatformPosY);
            ClearPlatforms();
            Random r = new Random();
            int x = r.Next(0, 280);
            PointF position = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(position);
            platforms.Add(platform);

            var c = r.Next(1, 3);

            switch (c)
            {
                case 1:
                    c = r.Next(1, 10);
                    if (c == 1)
                    {
                        CreateEnemy(platform);
                    }
                    break;
                case 2:
                    c = r.Next(1, 10);
                    if (c == 1)
                    {
                        CreateBonus(platform);
                    }
                    break;
            }
        }

        // Create a bonus and add it to the list
        public static void CreateBonus(Platform platform)
        {
            Random r = new Random();
            var bonusType = r.Next(1, 3);

            switch (bonusType)
            {
                case 1:
                    var bonus = new Bonus(new PointF(platform.transform.position.X + (platform.SizeX / 2) - 7, platform.transform.position.Y - 15), bonusType);
                    bonuses.Add(bonus);
                    break;
                case 2:
                    bonus = new Bonus(new PointF(platform.transform.position.X + (platform.SizeX / 2) - 15, platform.transform.position.Y - 30), bonusType);
                    bonuses.Add(bonus);
                    break;
            }
        }

        // Create an enemy and add it to the list
        public static void CreateEnemy(Platform platform)
        {
            Random r = new Random();
            var enemyType = r.Next(1, 4);

            switch (enemyType)
            {
                case 1:
                    var enemy = new Enemy(new PointF(platform.transform.position.X + (platform.SizeX / 2) - 20, platform.transform.position.Y - 40), enemyType);
                    enemies.Add(enemy);
                    break;
                case 2:
                    enemy = new Enemy(new PointF(platform.transform.position.X + (platform.SizeX / 2) - 35, platform.transform.position.Y - 50), enemyType);
                    enemies.Add(enemy);
                    break;
                case 3:
                    enemy = new Enemy(new PointF(platform.transform.position.X + (platform.SizeX / 2) - 35, platform.transform.position.Y - 60), enemyType);
                    enemies.Add(enemy);
                    break;
            }
        }

        // Remove an enemy from the list
        public static void RemoveEnemy(int i)
        {
            enemies.RemoveAt(i);
        }

        // Remove a bullet from the list
        public static void RemoveBullet(int i)
        {
            bullets.RemoveAt(i);
        }

        // Clear objects that are out of bounds
        public static void ClearPlatforms()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 700)
                {
                    platforms.RemoveAt(i);
                }
            }
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i].physics.transform.position.Y >= 700)
                {
                    bonuses.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].physics.transform.position.Y >= 700)
                {
                    enemies.RemoveAt(i);
                }
            }
        }
    }
}
