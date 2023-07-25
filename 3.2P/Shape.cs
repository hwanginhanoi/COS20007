using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape(Color color, float x, float y, int w, int h)
        {
            _color = color;
            _x = x;
            _y = y;
            _width = w;
            _height = h;
        }

        public Color Color
        {
            get

            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

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

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }


        public void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x - _width / 2, _y - _height / 2, _width, _height);
        }

        public bool isAt(Point2D mousePos)
        {
            if (mousePos.X <= _x + _width / 2 && mousePos.X >= _x - _width / 2 && mousePos.Y <= _y + _height / 2 && mousePos.Y >= _y - _height / 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, (_x - _width / 2) - 2, (_y - _height / 2) - 2, _width + 4, _height + 4);
        }
    }
}
