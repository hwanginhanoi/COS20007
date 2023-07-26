using System;
using SplashKitSDK;
using static System.Formats.Asn1.AsnWriter;

namespace Custom_Project
{
    public class GameUI
    {
        private const int CellSize = 30; // Size of each cell in pixels
        private const int BoardX = 50;   // X-coordinate of the top-left corner of the game board
        private const int BoardY = 50;   // Y-coordinate of the top-left corner of the game board

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
            int borderWidth = 4; // Adjust this value to control the thickness of the border

            for (int i = 0; i < borderWidth; i++)
            {
                int x = BoardX - i;
                int y = BoardY - i;
                int width = boardWidth + 2 * i;
                int height = boardHeight + 2 * i;
                SplashKit.DrawRectangle(Color.White, x, y, width, height);
            }

            //SplashKit.DrawRectangle(Color.Green, BoardX - 4, BoardY - 4, boardWidth + 8, boardHeight + 8);

            for (int row = 0; row < _gameState.Grid.Row; row++)
            {
                for (int col = 0; col < _gameState.Grid.Col; col++)
                {
                    int cellValue = _gameState.Grid[row, col];
                    Color cellColor = GetCellColor(cellValue);
                    SplashKit.FillRectangle(cellColor, BoardX + col * CellSize, BoardY + row * CellSize, CellSize, CellSize);
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
            // Define colors for different Tetromino IDs or empty cells
            switch (cellValue)
            {
                case 1: return Color.Red;
                case 2: return Color.Blue;
                case 3: return Color.Orange;
                case 4: return Color.Yellow;
                case 5: return Color.Green;
                case 6: return Color.Purple;
                case 7: return Color.Cyan;
                default: return Color.Black; // Empty cell color
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
                SplashKit.FillRectangle(cellColor, BoardX + col * CellSize, BoardY + row * CellSize, CellSize, CellSize);
            }
        }

        public void DrawNextTetromino(Queue queue)
        {
            Tetromino next = queue.NextTetromino;

            // Calculate the position where you want to draw the next Tetromino
            int nextTetrominoX = 200; // Set the X-coordinate
            int nextTetrominoY = 700; // Set the Y-coordinate

            foreach (Position position in next.TilePosition())
            {
                int row = position.Row;
                int col = position.Col;
                int cellValue = next.Id;
                Color cellColor = GetCellColor(cellValue);

                int drawX = nextTetrominoX + col * CellSize;
                int drawY = nextTetrominoY + row * CellSize;

                SplashKit.FillRectangle(cellColor, drawX, drawY, CellSize, CellSize);
            }
        }

        public void DrawScore(int score)
        {
            SplashKit.DrawText("Score: " + score, Color.Black, "Arial", 18, 500, 500);
        }

        public void DrawUI()
        {
            DrawNextTetromino(_gameState.Queue);
            DrawGameBoard();
            DrawFallingTetromino(_gameState.CurrentTetromino);
            DrawScore(_gameState.Score); // Draw the score after other elements
        }
    }
}
 