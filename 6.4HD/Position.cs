namespace Custom_Project
{
    public class Position
    {
        private int _row; // Holds the row index of the position
        private int _col; // Holds the column index of the position

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

        // Position with row and column index
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
