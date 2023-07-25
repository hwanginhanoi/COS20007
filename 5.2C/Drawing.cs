using System;
using System.IO;
using SplashKitSDK;


namespace ShapeDrawing;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;
    StreamWriter writer;
    StreamReader reader;

    public Drawing(Color background)
    {

        _shapes = new List<Shape>();
        _background = background;

    }

    public Drawing() : this(Color.White)
    {

    }

    public Color Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
        }
    }


    public int ShapeCount
    {
        get
        {
            return _shapes.Count;
        }
    }

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);

        foreach (Shape shape in _shapes)
        {
            shape.Draw();
        }
    }

    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> selectedShapes = new List<Shape>();

            foreach (Shape shape in _shapes)
            {
                if (shape.Selected == true)
                {
                    selectedShapes.Add(shape);
                }
            }

            return selectedShapes;
        }
    }

    public void SelectedShapesAt(Point2D point)
    {
        foreach (Shape shape in _shapes)
        {
            if (shape.isAt(point))
            {
                shape.Selected = true;
            }
            else
            {
                shape.Selected = false;
            }
        }
    }

    public void RemoveShape()
    {
        List<Shape> shapesToRemove = new List<Shape>();

        foreach (Shape shape in _shapes)
        {
            if (shape.Selected)
            {
                shapesToRemove.Add(shape);
            }
        }

        foreach (Shape shapeToRemove in shapesToRemove)
        {
            _shapes.Remove(shapeToRemove);
        }
    }

    public void Save(string filename)
    {
        writer = new StreamWriter(filename);

        try
        {
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            foreach (Shape shape in _shapes)
            {
                shape.SaveTo(writer);
            }
        }

        finally
        {
            writer.Close();

        }
    }

    public void Load(string filename)
    {
        Shape s;
        string kind;

        reader = new StreamReader(filename);

        Background = reader.ReadColor();
        int count = reader.ReadInteger();
        _shapes.Clear();

        try
        {
            for (int i = 0; i < count; i++)
            {
                kind = reader.ReadLine();
                switch (kind)
                {
                    case "Rectangle":
                        s = new MyRectangle();
                        break;
                    case "Circle":
                        s = new MyCircle();
                        break;
                    case "Line":
                        s = new MyLine();
                        break;
                    default:
                        throw new InvalidDataException("Unknown shape kind: " + kind);
                }

                s.LoadFrom(reader);
                AddShape(s);
            }
        }

        finally
        {
            reader.Close();
        }
        
    }

}