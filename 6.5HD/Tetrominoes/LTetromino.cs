using System;
namespace Custom_Project
{
    public class LTetromino : Tetromino
    {
        public override int Id => 3;

        protected override Position StartOfs => new(0, 3);

        protected override Position[][] Tiles => new Position[][] {
            new Position[] {new(0,2), new(1,0), new(1,1), new(1,2)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(2,2)},
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,0)},
            new Position[] {new(0,0), new(0,1), new(1,1), new(2,1)}
        };
    }
}

