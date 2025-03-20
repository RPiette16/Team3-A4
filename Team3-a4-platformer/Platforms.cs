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
                new Platform(0, 550, 100, 50),
                new Platform(150, 450, 50, 50),
                new Platform(250, 550, 50, 50),
                new Platform(350, 500, 50, 50),
                new Platform(400, 400, 100, 50),
                new Platform(550, 550, 200, 50),
                new Platform(750, 450, 50, 50),
                new Platform(650, 400, 50, 50),
                new Platform(750, 300, 50, 50),
                new Platform(650, 250, 50, 50),
                new Platform(750, 150, 50, 50),
                new Platform(650, 50, 50, 50),
                new Platform(550, 100, 50, 50),
                new Platform(450, 50, 50, 50),
                new Platform(350, 100, 50, 50),
                new Platform(250, 50, 50, 50),
                new Platform(50, 100, 200, 50),
                new Platform(0, 50, 50, 50),
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
