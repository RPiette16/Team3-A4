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
        public BoundingBox GetBoundingBox(int x1, int y1, int x2, int y2)
        {
            int minX = Math.Min(x1, x2);
            int maxX = Math.Max(x1, x2);
            int minY = Math.Min(y1, y2);
            int maxY = Math.Max(y1, y2);

            return new BoundingBox(minX, minY, maxX, maxY);
        }
        public bool CheckCollisionWithPlayer(Player player)
        {
            // Get the bounding box for each enemy square
            BoundingBox enemyBox1 = new BoundingBox((int)(55 + x), 500, 30, 30);
            BoundingBox enemyBox2 = new BoundingBox((int)(2 + x - 200), 55 , 30, 30);
            BoundingBox enemyBox3 = new BoundingBox(50, (int) (110 + y), 30, 30);
            //BoundingBox enemyBox4 = new BoundingBox(210, (int) (110 + y), 30, 30);
            BoundingBox enemyBox5 = new BoundingBox(310, (int) (110 + y), 30, 30);
            BoundingBox enemyBox6 = new BoundingBox(710, (int) (-100 + y), 30, 30);

            // Check for intersection with the player's bounding box
            return IsIntersecting(player, enemyBox1) ||
                   IsIntersecting(player, enemyBox2) ||
                   IsIntersecting(player, enemyBox3) ||
                   //IsIntersecting(player, enemyBox4) ||
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
        
            Draw.FillColor = Color.Clear;


            Graphics.Draw(Slime, (int)(55 + x), 500);
            Graphics.Draw(Slime, (int)(2 + x - 200), 55);
            Graphics.Draw(Slime, 50, (int)(110 + y));
            //Graphics.Draw(Slime, 210, (int)(110 + y));
            Graphics.Draw(Slime, 310, (int)(110 + y));
            Graphics.Draw(Slime, 710, (int)(-100 + y));



        }

    }
}