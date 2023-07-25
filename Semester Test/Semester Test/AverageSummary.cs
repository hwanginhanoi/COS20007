using System;

namespace Semester_Test
{
	public class AverageSummary : SummaryStrategy
	{
		private float Average(List<int> numbers)
		{
            float sum = 0;
            float count = numbers.Count();

            for (int index = 0; index < count; index++)
            {
                sum += numbers[index];
            }

            float average = sum / count;

            return average;
       
        }


		public override void PrintSummary(List<int> numbers)
		{
            Console.WriteLine("Average: " + Average(numbers));
		}
	}
}

