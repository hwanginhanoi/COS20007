using System;
using SplashKitSDK;

namespace Shape
{
    class Shape
    {
        Color _color;
        float _x, _y;
        int _width, _height;

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

        public void Draw()
        {
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
    }

    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape(Color.Green, 0, 0, 100, 100);
            Window window = new Window("Shape Drawer", 800,
            600);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (myShape.isAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        myShape.Color = Color.Random();
                    }
                }
                else
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        myShape.X = (float)SplashKit.MousePosition().X;
                        myShape.Y = (float)SplashKit.MousePosition().Y;
                    }
                }
                myShape.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
