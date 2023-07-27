namespace Custom_Project
{
    public class Program
    {
        static void Main()
        {
            const int WindowWidth = 900;
            const int WindowHeight = 900;

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
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(SplashKit.RGBColor(116, 116, 116));

                Console.WriteLine($"Time since last move down: {gameTimer.Elapsed.TotalSeconds - timeSinceLastMoveDown}");
                Console.WriteLine($"Next Tetromino: {gameState.Queue.NextTetromino.Id}");

                // ... (existing code)

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
                    gameState.RotateTetrominoCW();
                }
                else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    gameState.RotateTetrominoCCW();
                }

                // Handle user input for down movement
                if (SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    gameState.MoveDown();
                }

                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    gameState.DropBlock();
                }

                // Check if the game is over
                isGameOver = gameState.GameOver;

                // Clear the screen and draw the UI
                gameUI.DrawUI();

                if (isGameOver)
                {
                    gameUI.GameOverScreen();

                    // Handle restart functionality when 'R' key is pressed
                    if (SplashKit.KeyTyped(KeyCode.RKey))
                    {
                        gameState.RestartGame();
                        isGameOver = false;
                    }
                }

                SplashKit.RefreshScreen(70);
            }

            SplashKit.CloseWindow("Tetris Game");
        }


    }
}
