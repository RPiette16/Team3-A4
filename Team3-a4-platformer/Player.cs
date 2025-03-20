using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MohawkGame2D;

namespace MohawkGame2D
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; } = 5;
        public int VerticalSpeed { get; set; } = 0;
        public bool IsJumping { get; set; } = false;
        public bool IsFalling { get; set; } = false;

        public Player()
        {
            X = 10;
            Y = 500;
            Width = 30;
            Height = 30;
        }
        public void renderPlayer()
        {
            //Draw Character
            Draw.FillColor = Color.Magenta;
            Draw.Rectangle(X, Y, Width, Height);
        }
        public void movePlayer()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) && X + Width < 800)  // Right boundary
            {
                X += Speed;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left) && X > 0)  // Left boundary
            {
                X -= Speed;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space) && !IsJumping)
            {
                IsJumping = true;
                VerticalSpeed = -15;
            }
        }
        public void updateMovement(Platform[] platforms)
        {
            bool isOnGround = false;

            // Platform collisions
            foreach (var platform in platforms)
            {
                if (platform.CheckCollision(this))
                {

                    Y = platform.Y - Height;
                    VerticalSpeed = 0;
                    IsJumping = false;
                    isOnGround = true;
                    break;
                }
            }


            if (!isOnGround)
            {
                // Gravity effect
                VerticalSpeed += 1;
            }

            Y += VerticalSpeed;
            // Control fall speed
            if (VerticalSpeed > 10)
                VerticalSpeed = 10;
        }

    }
}
