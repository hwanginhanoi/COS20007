using SplashKitSDK;

namespace ShapeDrawing
{
    public class Program
    {
        public static void Main()
        {
            Drawing drawing = new Drawing();

            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    float x = SplashKit.MouseX();
                    float y = SplashKit.MouseY();
                    int width = 100;
                    int height = 100;
                    Color shapeColor = SplashKit.RandomRGBColor(255);

                    Shape shape = new Shape(shapeColor, x, y, width, height);
                    drawing.AddShape(shape);
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

