using System;

namespace MainClock
{
    class Program
    {
        static void Main()
        {
            Clock clock = new Clock();

            for (int i = 0; i < 86401; i++)
            {
                Thread.Sleep(0);
                clock.Tick();
                Console.WriteLine(clock.Time);
            }
        }
    }
}