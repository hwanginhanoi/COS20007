using Semester_Test;

namespace SemesterTest
{
    public class Program
    {
       public static void Main()
       {
            DataAnalyser dataAnalyser = new();
            dataAnalyser.Summarise();

            List<int> numbers = new List<int> { 1,0,4,1,8,0,3,9,1 };
            DataAnalyser DataAnalyser = new(numbers, new MinMaxSummary());
            DataAnalyser.Summarise();
            DataAnalyser.AddNumber(3);
            DataAnalyser.AddNumber(1);
            DataAnalyser.AddNumber(1);
            DataAnalyser.Strategy = new AverageSummary();
            DataAnalyser.Summarise();

            Console.ReadLine();

        }

    }
}