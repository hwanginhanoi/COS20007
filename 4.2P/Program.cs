using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Drawing drawing = new Drawing();

            ShapeKind kindToAdd = ShapeKind.Rectangle;

            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        drawing.AddShape(newRect);
                    }
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCirc = new MyCircle();
                        newCirc.X = SplashKit.MouseX();
                        newCirc.Y = SplashKit.MouseY();
                        drawing.AddShape(newCirc);
                    }
                    if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newLine.X = SplashKit.MouseX();
                        newLine.Y = SplashKit.MouseY();
                        drawing.AddShape(newLine);
                    }
                }

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton)) {
                    drawing.SelectedShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShape();
                }

                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}

