using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.RandomRGB(255), 0, 0, 100, 100) { }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X - Width / 2, Y - Height / 2, Width, Height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, (X - _width / 2) - 2, (Y - _height / 2) - 2, _width + 4, _height + 4);
        }

        public override bool isAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X - Width / 2, Y - Height / 2, Width, Height));
        }

    }
}
