using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoodleJump.Classes;

namespace DoodleJump
{
    public partial class Form1 : Form
    {
        Player player;
        Timer timer1;

        public Form1()
        {
            InitializeComponent();
            Init();

            // Initialize and start the game timer
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            // Set up keyboard event handlers
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);

            // Set background image and window size
            this.BackgroundImage = Properties.Resources.back;
            this.Height = 600;
            this.Width = 330;

            // Add a repaint event handler
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        // Initialize the game
        public void Init()
        {
            // Initialize platform list, player, and other game variables
            PlatformController.platforms = new List<Platform>();
            PlatformController.AddPlatform(new PointF(100, 400));
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            PlatformController.bullets.Clear();
            PlatformController.bonuses.Clear();
            PlatformController.enemies.Clear();
            player = new Player();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;

            if (player.IsShooting)
            {
                if (player.IsRight)
                {
                    player.sprite = Properties.Resources.man2_right;
                }
                else
                {
                    player.sprite = Properties.Resources.man2;
                }
            }

            switch (e.KeyCode.ToString())
            {
                case "Space":
                    PlatformController.CreateBullet(new PointF(player.physics.transform.position.X + player.physics.transform.size.Width / 2, player.physics.transform.position.Y));
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.thraw);
                    soundPlayer.Play();
                    player.IsShooting = false;
                    break;
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 6;
                    if (!player.IsRight)
                    {
                        player.IsRight = true;
                        player.ChangeSprite();
                    }
                    break;
                case "Left":
                    player.physics.dx = -6;
                    if (player.IsRight)
                    {
                        player.IsRight = false;
                        player.ChangeSprite();
                    }
                    break;
                case "Space":
                    player.sprite = Properties.Resources.man_shooting;
                    player.IsShooting = true;
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            // Update the game window title with the player's score
            this.Text = "Doodle Jump: Score - " + PlatformController.score;

            // Check if the player fell or collided with a platform
            if ((player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200) || player.physics.StandartCollidePlayerWithObjects(true, false))
            {
                // Reset the game if the player fell or collided
                Init();
            }

            // Handle bullet movement and collisions with enemies
            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    if (Math.Abs(PlatformController.bullets[i].physics.transform.position.Y - player.physics.transform.position.Y) > 500)
                    {
                        PlatformController.RemoveBullet(i);
                        continue;
                    }
                    PlatformController.bullets[i].MoveUp();
                }

                if (PlatformController.enemies.Count > 0)
                {
                    for (int i = 0; i < PlatformController.enemies.Count; i++)
                    {
                        if (PlatformController.enemies[i].physics.StandartCollide())
                        {
                            PlatformController.RemoveEnemy(i);
                            break;
                        }
                    }
                }
            }

            // Apply player physics and adjust screen position to follow the player
            player.physics.ApplyPhysics();
            FollowPlayer();

            // Check if the player is using a jetpack and update the player's sprite
            if (player.IsInJetpack())
            {
                player.ChangeSprite();
            }

            // Call the function to teleport the player if they go out of bounds
            player.TeleportIfOutOfBounds(this.Width);

            // Request a repaint of the game window
            Invalidate();
        }

        // Adjust the screen position to follow the player
        public void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;

            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }

            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                bullet.physics.transform.position.Y += offset;
            }

            for (int i = 0; i < PlatformController.enemies.Count; i++)
            {
                var enemy = PlatformController.enemies[i];
                enemy.physics.transform.position.Y += offset;
            }

            for (int i = 0; i < PlatformController.bonuses.Count; i++)
            {
                var bonus = PlatformController.bonuses[i];
                bonus.physics.transform.position.Y += offset;
            }
        }

        // Repaint the game window
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw platforms, bullets, enemies, bonuses, and player
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    PlatformController.platforms[i].DrawSprite(g);
                }
            }

            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    PlatformController.bullets[i].DrawSprite(g);
                }
            }

            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    PlatformController.enemies[i].DrawSprite(g);
                }
            }

            if (PlatformController.bonuses.Count > 0)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    PlatformController.bonuses[i].DrawSprite(g);
                }
            }

            player.DrawSprite(g);
        }

        // Handle form closing event
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
