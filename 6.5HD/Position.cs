namespace Custom_Project
{
    public class Position
    {
        private int _row; // Holds the row index of the position
        private int _col; // Holds the column index of the position

        // Public properties to access and modify the row and column indices
        public int Row
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
            }
        }

        public int Col
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
            }
        }

        // Constructor to initialize a Position object with row and column indices
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
