namespace Custom_Project
{
    public class Queue
    {
        // Array containing all the types of tetrominos
        private readonly Tetromino[] tetrominos = new Tetromino[]
        {
        new ITetromino(), new JTetromino(), new LTetromino(),
        new OTetromino(), new STetromino(), new TTetromino(), new ZTetromino()
        };

        private readonly Random random = new Random();
        private Tetromino[] bag;
        private int bagIndex = 0;

        // Property to get the next tetromino in the bag
        public Tetromino NextTetromino
        {
            get
            {
                return bag[bagIndex];
            }
        }

        // Constructor to initialize the queue and shuffle the tetrominos
        public Queue()
        {
            bag = ShuffleTetrominos();
        }

        // Method to shuffle the tetrominos using the bag randomization technique
        private Tetromino[] ShuffleTetrominos()
        {
            List<Tetromino> tetrominoList = new List<Tetromino>(tetrominos);
            int n = tetrominoList.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Tetromino value = tetrominoList[k];
                tetrominoList[k] = tetrominoList[n];
                tetrominoList[n] = value;
            }

            return tetrominoList.ToArray();
        }

        // Method to refill the bag with shuffled tetrominos when needed
        private void RefillBagIfNeeded()
        {
            if (bagIndex == bag.Length - 1)
            {
                bag = ShuffleTetrominos();
                bagIndex = 0;
            }
            else
            {
                bagIndex++;
            }
        }

        // Method to get the next tetromino and update the bag for the next generation
        public Tetromino GetAndUpdate()
        {
            Tetromino tetromino = NextTetromino;
            RefillBagIfNeeded();
            return tetromino;
        }
    }
}