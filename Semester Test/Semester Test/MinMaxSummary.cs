using System;

namespace Semester_Test
{
	public class MinMaxSummary : SummaryStrategy
	{
		private int Minimum(List<int> numbers)
		{
			int min = numbers.Min();
			return min;

        }

        private int Maximum(List<int> numbers)
		{
            int max = numbers.Max();
            return max;
        }

        public override void PrintSummary(List<int> numbers)
		{
			Console.WriteLine("Minimum number: " + Minimum(numbers));
            Console.WriteLine("Maximum number: " + Maximum(numbers));
        }

    }
}

