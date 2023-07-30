using System.Linq.Expressions;
using static System.Formats.Asn1.AsnWriter;

namespace Custom_Project
{
    public class GameUI
    {
        private const int CellSize = 40; // Size of each cell in pixels
        private const int PreviewCellSize = 30; // Size of each cell in pixels
        private const int BoardX = 50;   // X-coordinate of the top-left corner of the game board
        private const int BoardY = 50;   // Y-coordinate of the top-left corner of the game board
        private int level = 1;

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }

        }

        private GameState _gameState;

        public GameUI(GameState gameState)
        {
            _gameState = gameState;
        }

        public void DrawGameBoard()
        {
            // Calculate the width and height of the game board in pixels
            int boardWidth = _gameState.Grid.Col * CellSize;
            int boardHeight = _gameState.Grid.Row * CellSize;

            // Draw the border around the game board using SplashKit.DrawRectangle
            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = BoardX - i;
                int y = BoardY - i;
                int width = boardWidth + 2 * i;
                int height = boardHeight + 2 * i;
                SplashKit.DrawRectangle(SplashKit.RGBColor(176, 247, 234), x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = BoardX - i - 16;
                int y = BoardY - i - 16;
                int width = boardWidth + 32 + 2 * i;
                int height = boardHeight + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = BoardX - 4 - i;
                int y = BoardY - 4 - i;
                int width = boardWidth + 8 + 2 * i;
                int height = boardHeight + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }

            for (int row = 0; row < _gameState.Grid.Row; row++)
            {
                for (int col = 0; col < _gameState.Grid.Col; col++)
                {
                    int cellValue = _gameState.Grid[row, col];
                    Color cellColor = GetCellColor(cellValue);

                    // Calculate the coordinates of the current cell
                    int cellX = BoardX + col * CellSize;
                    int cellY = BoardY + row * CellSize;

                    // Calculate the coordinates of the right border of the cell
                    int rightBorderX = cellX + CellSize - 4;
                    int rightBorderY = cellY;

                    // Calculate the coordinates of the bottom border of the cell
                    int bottomBorderX = cellX;
                    int bottomBorderY = cellY + CellSize - 4;

                    // Fill the rest of the cell with the actual cell color
                    SplashKit.FillRectangle(cellColor, cellX, cellY, CellSize - 1, CellSize - 1);

                    // Draw the right border of the cell
                    SplashKit.FillRectangle(Color.Black, rightBorderX, rightBorderY, 4, CellSize);

                    // Draw the bottom border of the cell
                    SplashKit.FillRectangle(Color.Black, bottomBorderX, bottomBorderY, CellSize, 4);

                    // Draw the white reflection
                    if (cellValue != 0)
                    {
                        SplashKit.FillRectangle(Color.White, cellX, cellY, 4, 4);
                        SplashKit.FillRectangle(Color.White, cellX + 4, cellY + 4, 4, 4);
                        SplashKit.FillRectangle(Color.White, cellX + 8, cellY + 4, 4, 4);
                        SplashKit.FillRectangle(Color.White, cellX + 4, cellY + 8, 4, 4);
                    }
                }
            }
        }

        private Color GetCellColor(int cellValue)
        {
            switch (level)
            {
                case 1:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(219, 2, 206);
                        case 2: case 4: case 6: return SplashKit.RGBColor(248, 120, 248);
                        default: return Color.Black; // Empty cell color
                    }
                case 2:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(0, 86, 248);
                        case 2: case 4: case 6: return SplashKit.RGBColor(60, 192, 255);
                        default: return Color.Black; // Empty cell color
                    }
                case 3:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(0, 172, 0);
                        case 2: case 4: case 6: return SplashKit.RGBColor(185, 248, 20);
                        default: return Color.Black; // Empty cell color
                    }
                case 4:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(0, 86, 248);
                        case 2: case 4: case 6: return SplashKit.RGBColor(89, 220, 85);
                        default: return Color.Black; // Empty cell color
                    }
                case 5:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(231, 0, 90);
                        case 2: case 4: case 6: return SplashKit.RGBColor(85, 248, 152);
                        default: return Color.Black; // Empty cell color
                    }
                case 6:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(85, 248, 152);
                        case 2: case 4: case 6: return SplashKit.RGBColor(104, 134, 252);
                        default: return Color.Black; // Empty cell color
                    }
                case 7:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(248, 52, 0);
                        case 2: case 4: case 6: return SplashKit.RGBColor(127, 127, 127);
                        default: return Color.Black; // Empty cell color
                    }
                case 8:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(107, 68, 254);
                        case 2: case 4: case 6: return SplashKit.RGBColor(172, 0, 28);
                        default: return Color.Black; // Empty cell color
                    }
                case 9:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(0, 86, 248);
                        case 2: case 4: case 6: return SplashKit.RGBColor(248, 52, 0);
                        default: return Color.Black; // Empty cell color
                    }
                case 10:
                    switch (cellValue)
                    {
                        case 1: case 3: case 5: case 7: return SplashKit.RGBColor(248, 52, 0);
                        case 2: case 4: case 6: return SplashKit.RGBColor(255, 164, 69);
                        default: return Color.Black; // Empty cell color
                    }
                default:
                    return Color.Black; // Default color in case of unknown level
            }
        }


        public void DrawFallingTetromino(Tetromino tetromino)
        {
            foreach (Position position in tetromino.TilePosition())
            {
                int row = position.Row;
                int col = position.Col;
                int cellValue = tetromino.Id;
                Color cellColor = GetCellColor(cellValue);

                // Calculate the coordinates of the current cell
                int cellX = BoardX + col * CellSize;
                int cellY = BoardY + row * CellSize;

                // Calculate the coordinates of the right border of the cell
                int rightBorderX = cellX + CellSize - 4;
                int rightBorderY = cellY;

                // Calculate the coordinates of the bottom border of the cell
                int bottomBorderX = cellX;
                int bottomBorderY = cellY + CellSize - 4;

                // Fill the rest of the cell with the actual cell color
                SplashKit.FillRectangle(cellColor, cellX, cellY, CellSize - 1, CellSize - 1);

                // Draw the right border of the cell
                SplashKit.FillRectangle(Color.Black, rightBorderX, rightBorderY, 4, CellSize);

                // Draw the bottom border of the cell
                SplashKit.FillRectangle(Color.Black, bottomBorderX, bottomBorderY, CellSize, 4);

                // Draw the white reflection
                SplashKit.FillRectangle(Color.White, cellX, cellY, 4, 4);
                SplashKit.FillRectangle(Color.White, cellX + 4, cellY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, cellX + 8, cellY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, cellX + 4, cellY + 8, 4, 4);
            }
        }

        public void DrawNextTetrominoPreview(Tetromino nextTetromino)
        {

            // Calculate the position where you want to draw the next Tetromino preview
            int nextTetrominoX = 630; // Set the X-coordinate
            int nextTetrominoY = 100; // Set the Y-coordinate

            int borderWidth = 16; // Adjust this value to control the thickness of the border

            SplashKit.FillRectangle(Color.Black, 599 - 69, 99 - 49, 301, 189);

            for (int i = 0; i < borderWidth; i++)
            {
                int x = nextTetrominoX - i - 100;
                int y = nextTetrominoY - i - 50;
                int width = 300 + 2 * i;
                int height = 180 + 2 * i;
                SplashKit.DrawRectangle(SplashKit.RGBColor(176, 247, 234), x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = nextTetrominoX - i - 100 - 16;
                int y = nextTetrominoY - i - 50 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 180 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = nextTetrominoX - 104 - i;
                int y = nextTetrominoY - 54 - i;
                int width = 300 + 8 + 2 * i;
                int height = 180 + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }


            // Draw the cells of the Tetromino preview
            int offSetX = nextTetromino.TilePosition().ElementAt(0).Col * PreviewCellSize;
            int offSetY = nextTetromino.TilePosition().ElementAt(0).Row * PreviewCellSize;
            foreach (Position position in nextTetromino.TilePosition())
            {
                int row = position.Row;
                int col = position.Col;
                int cellValue = nextTetromino.Id;
                Color cellColor = GetCellColor(cellValue);

                int drawX = nextTetrominoX + col * PreviewCellSize - offSetX;
                int drawY = nextTetrominoY + row * PreviewCellSize - offSetY;

                // Draw the cell with a black border
                SplashKit.FillRectangle(cellColor, drawX, drawY, PreviewCellSize, PreviewCellSize);
                SplashKit.FillRectangle(Color.Black, drawX + PreviewCellSize - 4, drawY, 4, PreviewCellSize);
                SplashKit.FillRectangle(Color.Black, drawX, drawY + PreviewCellSize - 4, PreviewCellSize, 4);

                SplashKit.FillRectangle(Color.White, drawX, drawY, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 4, drawY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 8, drawY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 4, drawY + 8, 4, 4);
            }
        }

        public void DrawScore(int score)
        {
            int scoreX = 550;
            int scoreY = 300;

            SplashKit.FillRectangle(Color.Black, scoreX - 19, scoreY - 15, 320, 80);

            SplashKit.LoadFont("Jetbrain", "JetBrainsMonoNL-ExtraBold.ttf");

            SplashKit.DrawText("Score: " + score, Color.Cyan, "Jetbrain", 35, scoreX + 2, scoreY + 2);
            SplashKit.DrawText("Score: " + score, Color.White, "Jetbrain", 35, scoreX, scoreY);


            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = scoreX - i - 20;
                int y = scoreY - i - 10;
                int width = 300 + 2 * i;
                int height = 70 + 2 * i;
                SplashKit.DrawRectangle(SplashKit.RGBColor(176, 247, 234), x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = scoreX - i - 20 - 16;
                int y = scoreY - i - 10 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 70 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = scoreX - i - 24;
                int y = scoreY - i - 15;
                int width = 300 + 8 + 2 * i;
                int height = 70 + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }
        }

        public void DrawLevel()
        {
            int scoreX = 600;
            int scoreY = 470;

            SplashKit.FillRectangle(Color.Black, scoreX - 69, scoreY - 49, 301, 159);

            SplashKit.LoadFont("Jetbrain", "JetBrainsMonoNL-ExtraBold.ttf");

            SplashKit.DrawText("Level " + level, Color.DarkGray, "Jetbrain", 35, scoreX + 4, scoreY + 4);
            SplashKit.DrawText("Level " + level, Color.White, "Jetbrain", 35, scoreX, scoreY);

            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = scoreX - i - 70;
                int y = scoreY - i - 50;
                int width = 300 + 2 * i;
                int height = 160 + 2 * i;
                SplashKit.DrawRectangle(SplashKit.RGBColor(176, 247, 234), x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = scoreX - i - 20 - 66;
                int y = scoreY - i - 50 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 160 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = scoreX - i - 74;
                int y = scoreY - i - 54;
                int width = 300 + 8 + 2 * i;
                int height = 160 + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }
        }

        public void GameOverScreen()
        {
            int messageX = 580 + 20;
            int messageY = 470;

            SplashKit.FillRectangle(Color.Black, messageX - 69, messageY - 49, 301, 159);

            SplashKit.DrawText("Game Over", Color.White, "Jetbrain", 36, messageX - 20 + 1, messageY + 1);
            SplashKit.DrawText("Game Over", Color.Red, "Jetbrain", 36, messageX - 20, messageY);
            SplashKit.DrawText("Press R to restart", Color.White, "Jetbrain", 20, messageX - 27, messageY + 50);


            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = messageX - i - 70;
                int y = messageY - i - 50;
                int width = 300 + 2 * i;
                int height = 160 + 2 * i;
                SplashKit.DrawRectangle(Color.Red, x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = messageX - i - 20 - 66;
                int y = messageY - i - 50 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 160 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = messageX - i - 74;
                int y = messageY - i - 54;
                int width = 300 + 8 + 2 * i;
                int height = 160 + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }
        }

        public void DrawLeaderBoard()
        {
            int highscoreX = 550;
            int highscoreY = 700;
            // Path to the text file containing the scores
            string filePath = "Score.txt";

            // Read the scores from the file and store them in a list
            List<int> scores = new List<int>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int score))
                    {
                        scores.Add(score);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file: " + e.Message);
                return;
            }

            SplashKit.FillRectangle(Color.Black, highscoreX - 19, highscoreY - 49, 301, 200);

            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = highscoreX - i - 20;
                int y = highscoreY - i - 50;
                int width = 300 + 2 * i;
                int height = 200 + 2 * i;
                SplashKit.DrawRectangle(Color.Yellow, x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = highscoreX - i - 20 - 16;
                int y = highscoreY - i - 50 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 200 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            for (int i = 0; i < borderWidth - 8; i++)
            {
                int x = highscoreX - i - 24;
                int y = highscoreY - i - 54;
                int width = 300 + 8 + 2 * i;
                int height = 200 + 8 + 2 * i;
                SplashKit.DrawRectangle(Color.Black, x, y, width, height);
            }

            // Sort the scores in descending order
            scores.Sort((a, b) => b.CompareTo(a));

            // Get the top 5 highest scores
            List<int> top5Scores = scores.Take(5).ToList();

            int yOffset = highscoreY - 2;

            SplashKit.DrawText("Leaderboard", Color.Gray, "Jetbrain", 23, 605, 655);
            SplashKit.DrawText("Leaderboard", Color.Yellow, "Jetbrain", 23, 605 + 2, 655 + 2);


            int rank = 1; // Initialize rank counter
            foreach (int score in top5Scores)
            {
                string scoreText = $"{rank}. {score}";
                SplashKit.DrawText(scoreText, Color.White, "Jetbrain", 20, highscoreX + 1, yOffset + 1);
                switch (rank)
                {
                    case 1:
                        SplashKit.DrawText(scoreText, Color.Red, "Jetbrain", 20, highscoreX, yOffset);
                        break;
                    case 2:
                        SplashKit.DrawText(scoreText, Color.DeepSkyBlue, "Jetbrain", 20, highscoreX, yOffset);
                        break;
                    case 3:
                        SplashKit.DrawText(scoreText, Color.Green, "Jetbrain", 20, highscoreX, yOffset);
                        break;
                    default:
                        break;
                }
                yOffset += 26;
                rank++; // Increment the rank counter for the next score
            }
        }

        public void DrawUI()
        {
            DrawGameBoard();
            DrawNextTetrominoPreview(_gameState.Queue.NextTetromino); // Draw the next Tetromino preview
            DrawFallingTetromino(_gameState.CurrentTetromino);
            DrawScore(_gameState.Score); // Draw the score after other elements
            DrawLevel();
            DrawLeaderBoard();
        }
    }
}
 