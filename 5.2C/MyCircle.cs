using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.RandomRGB(255), 50) { }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 4);
        }

        public override bool isAt(Point2D pt)
        {
            double a = (double)(pt.X - X);
            double b = (double)(pt.Y - Y);

            if (Math.Sqrt(a * a + b * b) < _radius)
            {
                return true;
            }
            return false;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}
