
namespace Custom_Project
{
    public class OTetromino : Tetromino
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0,0), new(0,1), new(1,0), new(1,1) }
        };

        public override int Id => 4;
        protected override Position StartOfs => new Position(0, 4);
        protected override Position[][] Tiles => tiles;
    }
}