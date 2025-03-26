
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Enemy
    {
        Texture2D Slime = Graphics.LoadTexture("../../../assets/Slime.png");
        float y;
        float x;
        float speed = 200;
        float direction = 1;
        float maxY = 600;
        float minY = 0;
        float maxX = 800;
        float minX = 0;
        public int EnemyWidth = 30;
        public int EnemyHeight = 30;


        // Update the position of the enemy based on DeltaTime and direction
        public void enemyPosition()
        {
            

            y += Time.DeltaTime * speed * direction;

            // Check for collisions with top or bottom and reverse direction if necessary
            if (y >= maxY)
            {
                y = maxY;
                direction = -1;
            }
            if (y <= minY)
            {
                y = minY;
                direction = 1;
            }

            x += Time.DeltaTime * speed * direction;

            // Check for collisions with left or right and reverse direction if necessary
            if (x >= maxX)
            {
                x = maxX;
                direction = -1;
            }
            if (x <= minX)
            {
                x = minX;
                direction = 1;
            }
        }
        public class BoundingBox
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public BoundingBox(int x, int y, int width, int height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }
        }
        public BoundingBox GetBoundingBox(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int minX = Math.Min(Math.Min(x1, x2), x3);
            int maxX = Math.Max(Math.Max(x1, x2), x3);
            int minY = Math.Min(Math.Min(y1, y2), y3);
            int maxY = Math.Max(Math.Max(y1, y2), y3);

            return new BoundingBox(minX, minY, maxX - minX, maxY - minY);
        }
        public bool CheckCollisionWithPlayer(Player player)
        {
            // Get the bounding box for each enemy triangle
            BoundingBox enemyBox1 = GetBoundingBox((int)(140 + x), 500, (int)(140 + x), 500, (int)(210 + x), 540);
            BoundingBox enemyBox2 = GetBoundingBox((int)(125 + x), 55, (int)(140 + x), 85, (int)(110 + x), 85);
            BoundingBox enemyBox3 = GetBoundingBox(225, (int)(0 + y), 240, (int)(30 + y), 210, (int)(30 + y));
            BoundingBox enemyBox4 = GetBoundingBox(325, (int)(0 + y), 340, (int)(30 + y), 310, (int)(30 + y));
            BoundingBox enemyBox5 = GetBoundingBox(525, (int)(0 + y), 540, (int)(30 + y), 510, (int)(30 + y));
            BoundingBox enemyBox6 = GetBoundingBox(625, (int)(0 + y), 640, (int)(30 + y), 610, (int)(30 + y));

            // Check for intersection with the player's bounding box
            return IsIntersecting(player, enemyBox1) ||
                   IsIntersecting(player, enemyBox2) ||
                   IsIntersecting(player, enemyBox3) ||
                   IsIntersecting(player, enemyBox4) ||
                   IsIntersecting(player, enemyBox5) ||
                   IsIntersecting(player, enemyBox6);
        }

        // Check if two rectangles are intersecting
        public bool IsIntersecting(Player player, BoundingBox enemyBox)
        {
            return player.X < enemyBox.X + enemyBox.Width &&
                   player.X + player.Width > enemyBox.X &&
                   player.Y < enemyBox.Y + enemyBox.Height &&
                   player.Y + player.Height > enemyBox.Y;
        }

        public void renderEnemy()
        {
        
        Draw.FillColor = Color.Red;

        Graphics.Draw (Slime, 125 + x, 470);
        Graphics.Draw (Slime,125 + x, 50);
        //Graphics.Draw (Slime, 225, 0 + y, 240, 30 + y, 210, 30 + y);
        //Graphics.Draw (Slime, 325, 0 + y, 340, 30 + y, 310, 30 + y);
        //Graphics.Draw (Slime, 525, 0 + y, 540, 30 + y, 510, 30 + y);
        //Graphics.Draw (Slime, 625, 0 + y, 640, 30 + y, 610, 30 + y); 

        
        }

    }
}