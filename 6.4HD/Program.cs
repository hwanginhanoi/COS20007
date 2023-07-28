namespace Custom_Project
{
    public class Program
    {
        public static void Main()
        {
            const int WindowWidth = 900;
            const int WindowHeight = 900;

            SplashKit.OpenWindow("Tetris Game", WindowWidth, WindowHeight);
            GameState gameState = new GameState();
            GameUI gameUI = new GameUI(gameState);

            double initialMoveDownInterval = 0.5; // Initial speed of downward movement
            double moveDownInterval = initialMoveDownInterval; // Current speed of downward movement
            double timeSinceLastMoveDown = 0;

            Stopwatch gameTimer = new Stopwatch();
            gameTimer.Start();

            bool isGameOver = false;

            int level = 1; // Current level
            double timeToIncreaseDifficulty = 5.0; // Time interval to increase the difficulty (in seconds)
            double timeSinceLastDifficultyIncrease = 0;

            const int maximumLevel = 10; // Set the maximum difficulty level

            while (!SplashKit.WindowCloseRequested("Tetris Game"))
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(SplashKit.RGBColor(116, 116, 116));

                // Check if it's time to move the Tetromino down automatically
                if (gameTimer.Elapsed.TotalSeconds - timeSinceLastMoveDown >= moveDownInterval)
                {
                    gameState.MoveDown(); // Move the Tetromino down
                    timeSinceLastMoveDown = gameTimer.Elapsed.TotalSeconds; // Update the time of the last move
                }

                // Calculate the elapsed time since the last frame
                double deltaTime = gameTimer.Elapsed.TotalSeconds - timeSinceLastDifficultyIncrease;

                // Check if it's time to increase the difficulty
                if (deltaTime >= timeToIncreaseDifficulty && level < maximumLevel)
                {
                    level++; // Increase the level
                    gameUI.level++;
                    moveDownInterval = initialMoveDownInterval / Math.Sqrt(level); // Reduce the moveDownInterval to increase difficulty
                    timeSinceLastDifficultyIncrease = gameTimer.Elapsed.TotalSeconds; // Update the time of the last difficulty increase
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
                        level = 1; // Reset the level to 1
                        gameUI.level = 1;
                        moveDownInterval = initialMoveDownInterval; // Reset the moveDownInterval to its initial value
                        timeSinceLastDifficultyIncrease = gameTimer.Elapsed.TotalSeconds; // Reset the time of the last difficulty increase
                    }
                }

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseWindow("Tetris Game");
        }


    }
}
