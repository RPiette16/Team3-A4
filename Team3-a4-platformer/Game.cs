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
    private Texture2D BG = Graphics.LoadTexture("../../../assets/BG.png");
    private Texture2D sword = Graphics.LoadTexture("../../../assets/sword.png");
    Music background_music = Audio.LoadMusic("../../../assets/soundtrack.mp3");
    public GameState currentState = GameState.Running;
    // Place your variables here:
    Player player = new Player();
    Enemy enemy = new Enemy();
    Platform platform = new Platform(0, 0, 0, 0);
    
    // list of platforms
    Platform[] platforms = new Platform[]
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
    public void Setup()
    {
        Window.SetTitle("Dungeon Hopper");
        Window.SetSize(800, 600);
        Audio.Play(background_music);

    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
   
        
        int controllerIndex = 0;
        switch (currentState)
        {

            case GameState.Win:
                Window.ClearBackground(Color.Green);
                Text.Color = Color.White;
                Text.Size = 50;
                Font Text_Winner = Text.LoadFont("../../../assets/FANTASYMAGIST.otf");
                Text.Draw("You Win!", 300, 200, Text_Winner);

                Text.Size = 30;
                Text.Draw("Press [ENTER] or [O] to play again!", 220, 280, Text_Winner);
                // Reset game if enter is pressed
                if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;
                }
                if (Input.IsControllerButtonPressed(controllerIndex, ControllerButton.RightFaceDown))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;
                }
                return;


            case GameState.GameOver:
                Window.ClearBackground(Color.Red);
                Text.Color = Color.White;
                Text.Size = 50;
                Font Text_GameOver = Text.LoadFont("../../../assets/FANTASYMAGIST.otf");
                Text.Draw("Game Over!", 300, 200, Text_GameOver);

                Text.Size = 30;
                Text.Draw("Press [ENTER] or [O] to play again!", 220, 280, Text_GameOver);
                // Reset game if enter is pressed
                if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;
                }
                if (Input.IsControllerButtonDown(controllerIndex, ControllerButton.RightFaceDown))
                {
                    Setup();
                    currentState = GameState.Running;
                    player.X = 10;
                    player.Y = 500;
                }
                return;

            case GameState.Running:
                Window.ClearBackground(Color.Black);
                Graphics.Draw(BG, 0, 0);
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
        int controllerIndex = 0;
        // Draw the goal
        Draw.FillColor = Color.Green;
        Graphics.Draw(sword, goalWidth, goalHeight);
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
            if (Input.IsControllerButtonDown(controllerIndex, ControllerButton.RightFaceDown))
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
