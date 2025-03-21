// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;


// The namespace your code is in.
namespace MohawkGame2D;
public enum GameState
{
    Running,
    Win,
    GameOver
}
/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    public GameState currentState = GameState.Running;
    // Place your variables here:
    Player player = new Player();
    Enemy enemy = new Enemy();
    Platform platform = new Platform(0, 0, 0, 0);

    // list of platforms
    Platform[] platforms = new Platform[]
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
    public void Setup()
    {
        Window.SetTitle("Dungeon Hopper");
        Window.SetSize(800, 600);

    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        switch (currentState)
        {

            case GameState.Win:
                Window.ClearBackground(Color.Green);
                Text.Draw("You Win!", 400, 300);
                if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;// Reset game if enter is pressed 
                }
                return;


            case GameState.GameOver:
                Window.ClearBackground(Color.Red);
                Text.Draw("Game Over!", 400, 300);
                if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;
                }
                return;

            case GameState.Running:
                Window.ClearBackground(Color.Black);
                player.renderPlayer();
                enemy.renderEnemy();
                enemy.enemyPosition();
                platform.renderPlatforms();
                player.movePlayer();
                player.updateMovement(platforms);
                if (enemy.CheckCollisionWithPlayer(player))
                {
                    currentState = GameState.GameOver;   // Trigger game over if a collision is detected
                }
                renderGoal();
                if (player.Y > 600)
                {
                    currentState = GameState.GameOver;
                }
                break;

        }
    }
    public void renderGoal()
    {
        int goalX = 0;
        int goalY = 0;
        int goalWidth = 50;
        int goalHeight = 50;

        // Draw the goal
        Draw.FillColor = Color.Green;
        Draw.Rectangle(goalX, goalY, goalWidth, goalHeight);

        // Check for collision with the player
        if (IsCollidingWithGoal(goalX, goalY, goalWidth, goalHeight))
        {
            currentState = GameState.Win;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
            {
                Setup();
                currentState = GameState.Running;
                player.X = 10;
                player.Y = 500;
            }
            return;

        }
    }
    public bool IsCollidingWithGoal(int goalX, int goalY, int goalWidth, int goalHeight)
    {
        // Check if the player’s bounding box intersects with the goal square
        if (player.X < goalX + goalWidth &&
            player.X + player.Width > goalX &&
            player.Y < goalY + goalHeight &&
            player.Y + player.Height > goalY)
        {
            // Collision detected, player reached the goal
            return true;
        }
        return false;
    }
}






