namespace Custom_Project
{
    public class Program
    {
        public static void Main(string[] args)
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
            bool isScoreWritten = false;

            int level = 1; // Current level
            double timeToIncreaseDifficulty = 120.0; // Time interval to increase the difficulty (in seconds)
            double timeSinceLastDifficultyIncrease = 0;

            bool opened = false;

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
                    gameUI.Level = level;
                    moveDownInterval = initialMoveDownInterval / Math.Sqrt(level); // Reduce the moveDownInterval to increase difficulty
                    timeSinceLastDifficultyIncrease = gameTimer.Elapsed.TotalSeconds; // Update the time of the last difficulty increase
                }

                // Handle user input for left and right movement
                if (InputController.IsKeyTyped(KeyCode.LeftKey))
                {
                    gameState.MoveLeft();
                }
                else if (InputController.IsKeyTyped(KeyCode.RightKey))
                {
                    gameState.MoveRight();
                }

                // Handle user input for rotation
                if (InputController.IsKeyTyped(KeyCode.UpKey))
                {
                    gameState.RotateTetrominoCW();
                }
                else if (InputController.IsKeyTyped(KeyCode.SpaceKey))
                {
                    gameState.RotateTetrominoCCW();
                }

                // Handle user input for down movement
                if (InputController.IsKeyTyped(KeyCode.DownKey))
                {
                    gameState.MoveDown();
                }

                if (InputController.IsKeyTyped(KeyCode.HKey))
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

                    if (!isScoreWritten)
                    {
                        gameUI.GameOverScreen();
                        using (StreamWriter writetext = new StreamWriter("Score.txt", true))
                        {
                            writetext.WriteLine(gameState.Score);
                        }
                        isScoreWritten = true; // Set the flag to true indicating that the score has been written
                    }

                    // Handle restart functionality when 'R' key is pressed
                    if (InputController.IsKeyTyped(KeyCode.RKey))
                    {
                        gameState.RestartGame();
                        isGameOver = false;
                        isScoreWritten = false; // Reset the flag to false for the new game
                        level = 1; // Reset the level to 1
                        gameUI.Level = level;
                        moveDownInterval = initialMoveDownInterval; // Reset the moveDownInterval to its initial value
                        timeSinceLastDifficultyIncrease = gameTimer.Elapsed.TotalSeconds; // Reset the time of the last difficulty increase
                    }
                }

                SplashKit.RefreshScreen(120);
            }

            SplashKit.CloseWindow("Tetris Game");
        }
    }
}
