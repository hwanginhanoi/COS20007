namespace Custom_Project
{
	public class Grid
	{
		private readonly int[,] grid; // 2D array to represent the grid

        public int Row { get; } // Readonly property for the number of rows in the grid
        public int Col { get; } // Readonly property for the number of columns in the grid

        // Indexer to access grid cells using row and column indices
        public int this[int r, int c]
		{
			get
			{
				return grid[r, c];
			}
			set
			{
				grid[r, c] = value;
			}
		}

        // Grid constructor with row and column dimensions
        public Grid(int row, int col)
		{
            Row = row;
            Col = col;
			grid = new int[row, col];
		}

        // Check if the given row and column indices are inside the grid boundaries
        public bool IsInside(int r, int c)
		{
			return r >= 0 && r < Row && c >= 0 && c < Col;
		}

        // Check if the specified cell is empty (value equals 0)
        public bool IsEmpty(int r, int c)
		{
			return IsInside(r, c) && grid[r, c] == 0;
		}

        // Check if the specified row is full (all cells are non-zero)
        public bool IsRowFull(int r)
		{
			for (int c = 0; c < Col; c++)
			{
				if (grid[r, c] == 0)
				{
					return false;
				}
			}

			return true;
		}

        // Check if the specified row is empty (all cells are zero)
        public bool IsRowEmpty(int r)
		{
            for (int c = 0; c < Col; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Clear the specified row by setting all cells to zero
        private void ClearRow(int r)
        {
			for (int c = 0; c < Col; c++)
            {
                grid[r, c] = 0;
            }
		}

        // Move the specified row down by the specified number of rows
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Col; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        // Clear full rows from the grid and return the number of cleared rows
        public int ClearFullRow()
		{
            // Variable to count cleared rows and calculate points
            int cleared = 0;

            for (int r = Row - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }

        public void ClearGrid()
        {
            for (int r = 0; r < Row; r++)
            {
                for (int c = 0; c < Col; c++)
                {
                    grid[r, c] = 0;
                }
            }
        }
    }
}

