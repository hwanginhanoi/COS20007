using Custom_Project;

public class Queue
{
    private readonly Tetromino[] tetrominos = new Tetromino[]
    {
        new ITetromino(), new JTetromino(), new LTetromino(),
        new OTetromino(), new STetromino(), new TTetromino(), new ZTetromino()
    };

    private readonly Random random = new Random();
    private Tetromino[] bag;
    private int bagIndex = 0;

    public Tetromino NextTetromino
    {
        get
        {
            return bag[bagIndex];
        }
    }

    public Queue()
    {
        bag = ShuffleTetrominos();
    }

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

    public Tetromino GetAndUpdate()
    {
        Tetromino tetromino = NextTetromino;
        RefillBagIfNeeded();
        return tetromino;
    }
}
