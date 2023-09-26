﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public static class PlatformController
    {
        public static List<Platform> platforms;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static int startPlatformPosY = 400;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform plateform = new Platform(position);
            platforms.Add(plateform);
        }

        public static void CreateBullet(PointF pos)
        {
            var bullet = new Bullet(pos);
            bullets.Add(bullet);
        }

        public static void GenerateStartSequence()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(30, 40);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position);
                platforms.Add(platform);

            }
        }

        public static void GenerateRandomPlatform()
        {
            Random r = new Random();
            int x = r.Next(0,270);
            PointF position = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(position);
            platforms.Add(platform);

            var c = r.Next(1, 5);
            if (c == 1)
            {
                CreateEnemy(platform);
            }
        }

        public static void CreateEnemy(Platform platform)
        {
            var enemy = new Enemy(new PointF(platform.transform.position.X + (platform.SizeX/2)/2, platform.transform.position.Y-40));
            enemies.Add(enemy);
        }

        public static void ClearPlatforms()
        {
            for (int i = 0;i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y>=700)
                {
                    platforms.RemoveAt(i);
                }
            }
        }
    }
}
