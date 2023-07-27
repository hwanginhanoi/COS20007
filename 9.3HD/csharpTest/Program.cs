using System;
using System.Diagnostics;
using System.Linq;

public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double Area()
    {
        return length * width;
    }
}

class Program
{
    static void Main()
    {
        // Function to benchmark the area calculation for multiple rectangles
        void Benchmark()
        {
            var rectangles = Enumerable.Range(1, 1000000).Select(_ => new Rectangle(5, 10));
            double totalArea = rectangles.Sum(rectangle => rectangle.Area());
        }

        // Create a Stopwatch instance to measure the execution time
        Stopwatch stopwatch = new Stopwatch();

        // Perform the benchmark and measure the execution time
        stopwatch.Start();
        for (int i = 0; i < 100; i++)  // Run the benchmark 100 times
        {
            Benchmark();
        }
        stopwatch.Stop();

        // Calculate the average execution time per iteration
        double averageTime = (double)stopwatch.ElapsedMilliseconds / 100.0 / 1000.0;
        Console.WriteLine($"Average Execution Time for 3x Intensive Rectangle Area (C#): {averageTime:F15} seconds");

    }
}
