using SplashKitSDK;
using System.Diagnostics;
using System.Diagnostics;
using System.Threading;

namespace Custom_Project
{
    public class Program
    {
        static void Main()
        {
            const int WindowWidth = 400;
            const int WindowHeight = 800;

            SplashKit.OpenWindow("Tetris Game", WindowWidth, WindowHeight);
            GameState gameState = new GameState();
            GameUI gameUI = new GameUI(gameState);

            const double MoveDownInterval = 0.5; // Adjust this value to control the speed of downward movement
            double timeSinceLastMoveDown = 0;

            Stopwatch gameTimer = new Stopwatch();
            gameTimer.Start();

            bool isGameOver = false;

            while (!SplashKit.WindowCloseRequested("Tetris Game"))
            {
                // Calculate the elapsed time since the last frame

                // Check if it's time to move the Tetromino down automatically
                if (gameTimer.Elapsed.TotalSeconds - timeSinceLastMoveDown >= MoveDownInterval)
                {
                    gameState.MoveDown(); // Move the Tetromino down
                    timeSinceLastMoveDown = gameTimer.Elapsed.TotalSeconds; // Update the time of the last move
                }

                // Handle user input for left and right movement
                if (SplashKit.KeyTyped(KeyCode.LeftKey))
                {
                    gameState.MoveLeft();
                }
                else if (SplashKit.KeyTyped(KeyCode.RightKey))
                {
                    gameState.MoveRight();
                }

                // Handle user input for rotation
                if (SplashKit.KeyTyped(KeyCode.UpKey))
                {
                    gameState.RotateBlockCW();
                }
                else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    gameState.RotateBlockCCW();
                }

                // Handle user input for down movement
                if (SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    gameState.MoveDown();
                }

                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    gameState.MoveDown();
                    gameState.MoveDown();
                    gameState.MoveDown();
                    gameState.MoveDown();
                    gameState.MoveDown();
                    gameState.MoveDown();
                    gameState.MoveDown();
                }

                // Check if the game is over
                isGameOver = gameState.GameOver;

                // Clear the screen and draw the UI
                SplashKit.ClearScreen();
                gameUI.DrawUI();

                SplashKit.RefreshScreen(70);
                SplashKit.ProcessEvents();
            }

            SplashKit.CloseWindow("Tetris Game");
        }
    }
}
