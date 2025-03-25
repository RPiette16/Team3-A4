using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Platform
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Platform(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void renderPlatforms()
        {
            Platform[] platforms = new Platform[18]
            {
                new Platform(0, 550, 50, 50),
                new Platform(100, 450, 50, 50),
                new Platform(150, 550, 150, 50),
                new Platform(200, 350, 50, 50),
                new Platform(350, 450, 50, 50),
                new Platform(500, 550, 300, 50),
                new Platform(750, 450, 50, 50),
                new Platform(650, 400, 50, 50),
                new Platform(550, 350, 50, 50),
                new Platform(400, 300, 50, 50),
                new Platform(500, 200, 50, 50),
                new Platform(600, 150, 50, 50),
                new Platform(450, 50, 150, 50),
                new Platform(350, 100, 50, 50),
                new Platform(250, 100, 50, 50),
                new Platform(150, 100, 50, 50),
                new Platform(150, 100, 50, 50),
                new Platform(50, 100, 50, 50),
            };
            foreach (var platform in platforms)
            {
                Draw.FillColor = Color.DarkGray;
                Draw.Rectangle(platform.X, platform.Y, platform.Width, platform.Height);
            }
        }

        public bool CheckCollision(Player player)
        {
            // Check if the player is falling and the player's bottom edge is within the platform
            if (player.VerticalSpeed > 0 &&
                player.X + player.Width > X && player.X < X + Width &&
                player.Y + player.Height <= Y + player.VerticalSpeed &&
                player.Y + player.Height + player.VerticalSpeed >= Y)
            {
                return true;
            }
            return false;
        }
    }
}
