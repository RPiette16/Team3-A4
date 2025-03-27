using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohawkGame2D;

namespace MohawkGame2D
{
    public class Player
    {
        Texture2D playersprite = Graphics.LoadTexture("../../../assets/playersprite.png");
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; } = 5;
        public int VerticalSpeed { get; set; } = 0;
        public bool IsJumping { get; set; } = false;
        public bool IsFalling { get; set; } = false;
        Sound JumpSound = Audio.LoadSound("../../../assets/Jump.mp3");

        public Player()
        {
            X = 10;
            Y = 500;
            Width = 30;
            Height = 30;
        }
        public void renderPlayer()
        {
            Draw.FillColor = Color.Magenta;
            Draw.Rectangle(X, Y, Width, Height);
            Graphics.Draw(playersprite, X, Y);
        }

        public void movePlayer()
        {
            //Controller input
            int controllerIndex = 0;

            
            if (Input.IsControllerButtonPressed(controllerIndex, ControllerButton.RightFaceLeft) && !IsJumping)
            {
                IsJumping = true;
                VerticalSpeed = -15;
                
            }
            if (Input.IsControllerButtonPressed(controllerIndex, ControllerButton.RightFaceDown) && !IsJumping)
            {
                IsJumping = true;
                VerticalSpeed = -15;
                
            }
            if (Input.IsControllerButtonPressed(controllerIndex, ControllerButton.RightFaceRight) && !IsJumping)
            {
                IsJumping = true;
                VerticalSpeed = -15;
                
            }
            if (Input.IsControllerButtonPressed(controllerIndex, ControllerButton.RightFaceUp) && !IsJumping)
            {
                IsJumping = true;
                VerticalSpeed = -15;
               
            }

            X += (int)(Input.GetControllerAxis(0, ControllerAxis.LeftX) * Speed);

            //Keyboard input
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
                Audio.Play(JumpSound);
            }

        }

        public void updateMovement(Platform[] platforms)
        {
            bool isOnGround = false;

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
                VerticalSpeed += 1;
            }

            Y += VerticalSpeed;

            if (VerticalSpeed > 10)
                VerticalSpeed = 10;
        }
    }
}










