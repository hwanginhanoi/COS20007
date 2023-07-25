namespace Custom_Project
{

	public abstract class Tetromino
	{
        // Abstract property to represent the different tile positions of the tetromino in different rotation states
        protected abstract Position[][] Tiles
        {
            get;
        }

        // Abstract property representing the starting offset position of the tetromino
        protected abstract Position StartOfs
        {
            get;
        }

        // Abstract property representing the unique ID of the tetromino
        public abstract int Id
        {
            get;
        }

        private int rotState; // The current rotation state of the tetromino
        private Position ofs; // The offset position of the tetromino

        // Tetromino constructor
        public Tetromino()
        {
            ofs = new Position(StartOfs.Row, StartOfs.Col);
        }

        // Get the positions of the tiles in the current rotation state, accounting for the offset
        public IEnumerable<Position> TilePosition()
        {
            foreach (Position pos in Tiles[rotState])
            {
                yield return new Position(pos.Row + ofs.Row, pos.Col + ofs.Col);
            }
        }

        // Rotate the tetromino clockwise
        public void RotateCW()
        {
            rotState = (rotState + 1) % Tiles.Length;

        }

        // Rotate the tetromino counterclockwise
        public void RotateCCW()
        {
            if (rotState == 0)
            {
                rotState = Tiles.Length - 1;
            }
            else
            {
                rotState--;
            }
        }

        // Move the tetromino by the specified number of rows and columns
        public void Move(int rows, int cols)
        {
            ofs.Row += rows;
            ofs.Col += cols;
        }

        // Reset the tetromino to its initial state
        public void Reset()
        {
            rotState = 0;
            ofs.Row = StartOfs.Row;
            ofs.Col = StartOfs.Col;
        }
    }
}

