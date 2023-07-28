namespace Custom_Project
{
    public class GameUI
    {
        private const int CellSize = 40; // Size of each cell in pixels
        private const int BoardX = 50;   // X-coordinate of the top-left corner of the game board
        private const int BoardY = 50;   // Y-coordinate of the top-left corner of the game board
        private const int WindowWidth = 900; // Set the window width
        private const int WindowHeight = 900; // Set the window height

        public int level = 1;

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

        public void GameOverScreen()
        {
            // Calculate the position to display the game over message
            int messageX = (BoardX + _gameState.Grid.Col * CellSize) / 2;
            int messageY = (BoardY + _gameState.Grid.Row * CellSize) / 2;

            // Draw the game over message on the screen
            SplashKit.DrawText("Game Over", Color.Red, "Arial", 36, messageX, messageY);
        }

        private Color GetCellColor(int cellValue)
        {
            switch (level)
            {
                case 1:
                    switch (cellValue)
                    {
                        case 1: return SplashKit.RGBColor(219, 2, 206);
                        case 2: return SplashKit.RGBColor(248, 120, 248);
                        case 3: return SplashKit.RGBColor(219, 2, 206);
                        case 4: return SplashKit.RGBColor(248, 120, 248);
                        case 5: return SplashKit.RGBColor(219, 2, 206);
                        case 6: return SplashKit.RGBColor(248, 120, 248);
                        case 7: return SplashKit.RGBColor(219, 2, 206);
                        default: return Color.Black; // Empty cell color
                    }
                case 2:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 3:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 4:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 5:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 6:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 7:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 8:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 9:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
                        default: return Color.Black; // Empty cell color
                    }
                case 10:
                    switch (cellValue)
                    {
                        case 1: return Color.AliceBlue;
                        case 2: return Color.AliceBlue;
                        case 3: return Color.AliceBlue;
                        case 4: return Color.AliceBlue;
                        case 5: return Color.AliceBlue;
                        case 6: return Color.AliceBlue;
                        case 7: return Color.AliceBlue;
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

            for (int i = 0; i < borderWidth; i++)
            {
                int x = nextTetrominoX - i - 100;
                int y = nextTetrominoY - i - 50;
                int width =  300 + 2 * i;
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


            // Draw the cells of the Tetromino preview
            int offSetX = nextTetromino.TilePosition().ElementAt(0).Col * CellSize;
            int offSetY = nextTetromino.TilePosition().ElementAt(0).Row * CellSize;
            foreach (Position position in nextTetromino.TilePosition())
            {
                int row = position.Row;
                int col = position.Col;
                int cellValue = nextTetromino.Id;
                Color cellColor = GetCellColor(cellValue);

                int drawX = nextTetrominoX + col * CellSize - offSetX;
                int drawY = nextTetrominoY + row * CellSize - offSetY;

                // Draw the cell with a black border
                SplashKit.FillRectangle(cellColor, drawX, drawY, CellSize, CellSize);
                SplashKit.FillRectangle(Color.Black, drawX + CellSize - 4, drawY, 4, CellSize);
                SplashKit.FillRectangle(Color.Black, drawX, drawY + CellSize - 4, CellSize, 4);

                SplashKit.FillRectangle(Color.White, drawX, drawY, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 4, drawY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 8, drawY + 4, 4, 4);
                SplashKit.FillRectangle(Color.White, drawX + 4, drawY + 8, 4, 4);
            }
        }

        public void DrawScore(int score)
        {
            int scoreX = 500;
            int scoreY = 500;

            SplashKit.DrawText("Score: " + score, Color.Black, "Arial", 18, scoreX, scoreY);

            int borderWidth = 16; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = scoreX - i - 100;
                int y = scoreY - i - 50;
                int width = 300 + 2 * i;
                int height = 180 + 2 * i;
                SplashKit.DrawRectangle(SplashKit.RGBColor(176, 247, 234), x, y, width, height);
            }

            for (int i = 0; i < 8; i++)
            {
                int x = scoreX - i - 100 - 16;
                int y = scoreY - i - 50 - 16;
                int width = 300 + 32 + 2 * i;
                int height = 180 + 32 + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }
        }

        public void DrawUI()
        {
            DrawGameBoard();
            DrawNextTetrominoPreview(_gameState.Queue.NextTetromino); // Draw the next Tetromino preview
            DrawFallingTetromino(_gameState.CurrentTetromino);
            DrawScore(_gameState.Score); // Draw the score after other elements
        }
    }
}
 