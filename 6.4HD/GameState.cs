namespace Custom_Project
{
    public class GameState
    {
        private Tetromino currentTetromino;

        public Tetromino CurrentTetromino
        {
            get
            {
                return currentTetromino;
            }

            private set
            {
                currentTetromino = value;

                currentTetromino.Reset();
            }
        }

        private bool isGameOver;

        public bool GameOver
        {
            get { return isGameOver; }
            private set { isGameOver = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        public Tetromino HoldTetromino
        {
            get
            {
                return HoldTetromino;
            }

            private set
            {
                HoldTetromino = value;
            }
        }

        public Grid Grid
        {
            get;
        }

        public Queue Queue
        {
            get;
        }

        public GameState()
        {
            Grid = new Grid(20, 10);
            Queue = new Queue();
            CurrentTetromino = Queue.GetAndUpdate();
        }

        private bool TetrominoFits()
        {
            foreach (Position position in CurrentTetromino.TilePosition())
            {
                if (!Grid.IsEmpty(position.Row, position.Col))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlockCW()
        {
            CurrentTetromino.RotateCW();

            if (!TetrominoFits())
            {
                CurrentTetromino.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            CurrentTetromino.RotateCCW();

            if (!TetrominoFits())
            {
                CurrentTetromino.RotateCW();
            }
        }

        public void MoveLeft()
        {
            CurrentTetromino.Move(0, -1);

            if (!TetrominoFits())
            {
                CurrentTetromino.Move(0, 1);
            }
        }

        public void MoveRight()
        {
            CurrentTetromino.Move(0, 1);

            if (!TetrominoFits())
            {
                CurrentTetromino.Move(0, -1);
            }
        }

        public void MoveDown()
        {
            CurrentTetromino.Move(1, 0);

            if (!TetrominoFits())
            {
                CurrentTetromino.Move(-1, 0);
                PlaceBlock();
            }
        }

        private bool IsGameOver()
        {
            return !(Grid.IsRowEmpty(0) && Grid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (Position position in CurrentTetromino.TilePosition())
            {
                int row = position.Row;
                int col = position.Col;

                // Check if the row and column indices are within the grid boundaries
                if (row >= 0 && row < Grid.Row && col >= 0 && col < Grid.Col)
                {
                    Grid[row, col] = CurrentTetromino.Id;
                }
            }

            int lineClears = Grid.ClearFullRow();

            switch (lineClears)
            {
                case 1:
                    Score += 100; // Single Line Clear: 100 Points
                    break;
                case 2:
                    Score += 300; // Double Line Clear: 300 Points
                    break;
                case 3:
                    Score += 500; // Triple Line Clear: 500 Points
                    break;
                case 4:
                    Score += 800; // Tetris Line Clear: 800 Points
                    break;
            }

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentTetromino = Queue.GetAndUpdate();
            }
        }

        private int TileDropDistance(Position position)
        {
            int drop = 0;

            while (Grid.IsEmpty(position.Row + drop + 1, position.Col))
            {
                drop++;
            }

            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = Grid.Row;

            foreach (Position position in CurrentTetromino.TilePosition())
            {
                drop = Math.Min(drop, TileDropDistance(position));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentTetromino.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }

        public void RestartGame()
        {
            // Reset all the game state variables
            CurrentTetromino = Queue.GetAndUpdate();
            GameOver = false;
            Score = 0;
            Grid.ClearGrid(); // Assuming you have a ClearGrid() method in the Grid class to reset the grid to an empty state
        }
    }
}
