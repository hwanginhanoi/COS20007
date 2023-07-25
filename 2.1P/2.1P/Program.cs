
namespace Counter;

public class Counter
{
    int _count = 0;
    string _name = "";

    public Counter(string name)
    {
        _name = name;
    }

    public void Reset()
    {
        _count = 0;
    }

    public void Increment()
    {
        _count++;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public int Ticks
    {
        get
        {
            return _count;
        }
    }
}

public class MainClass
{

    private static void PrintCounters(Counter[] counters)
    {
        foreach (Counter counter in counters)
        {
            Console.WriteLine("{0} is {1}", counter.Name, counter.Ticks);
        }
    }
    public static void Main(string[] args)
    {
        Counter[] myCounters = new Counter[3];

        myCounters[0] = new Counter("Counter 1");
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0];

        for (int i = 0; i < 9; i++)
        {
            myCounters[0].Increment();
        }
        for (int i = 0; i < 14; i++)
        {
            myCounters[1].Increment();
        }
        PrintCounters(myCounters);
        myCounters[2].Reset();
        PrintCounters(myCounters);
        Console.ReadKey();
    }
}

