using System;
using SplashKitSDK;

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
            for (int row = 0; row < _gameState.Grid.Row; row++)
            {
                for (int col = 0; col < _gameState.Grid.Col; col++)
                {
                    int cellValue = _gameState.Grid[row, col];
                    Color cellColor = GetCellColor(cellValue);
                    SplashKit.FillRectangle(cellColor, BoardX + col * CellSize, BoardY + row * CellSize, CellSize, CellSize);
                    SplashKit.DrawRectangle(Color.White, BoardX + col * CellSize, BoardY + row * CellSize, CellSize, CellSize);

                }
            }
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
                SplashKit.DrawRectangle(Color.White, BoardX + col * CellSize, BoardY + row * CellSize, CellSize, CellSize);
            }
        }

        public void DrawUI()
        {
            DrawGameBoard();
            DrawFallingTetromino(_gameState.CurrentTetromino);
        }
    }
}
