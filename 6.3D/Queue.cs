using System;

namespace Custom_Project
{
    public class Queue
    {
        private readonly Tetromino[] tetrominos = new Tetromino[]
        {
            new ITetromino(), new JTetromino(), new LTetromino(),
            new OTetromino(), new STetromino(), new TTetromino(), new ZTetromino()
        };

        private readonly Random random = new Random();
        private Tetromino nextTetromino; // Private field to store the next Tetromino

        public Tetromino NextTetromino
        {
            get
            {
                return nextTetromino;
            }
        }

        public Queue()
        {
            nextTetromino = RandomTetromino(); // Set the initial value during object initialization
        }

        private Tetromino RandomTetromino()
        {
            return tetrominos[random.Next(tetrominos.Length)];
        }

        public Tetromino GetAndUpdate()
        {
            Tetromino tetromino = nextTetromino;
            nextTetromino = RandomTetromino(); // Update the nextTetromino with a new random Tetromino

            while (tetromino.Id == nextTetromino.Id)
            {
                nextTetromino = RandomTetromino(); // Keep updating until a different Tetromino is obtained
            }

            return tetromino;
        }
    }
}
