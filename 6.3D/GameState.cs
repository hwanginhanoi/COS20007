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


        private bool holdable;

        public bool Holdable
        {
            get { return holdable; }
            private set { holdable = value; }
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

            Score += Grid.ClearFullRow();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentTetromino = Queue.GetAndUpdate();
                Holdable = true;
            }
        }

    }
}
