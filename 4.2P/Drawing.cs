using System;
using System.Collections.Generic;
using SplashKitSDK;


namespace ShapeDrawing;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;

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

}