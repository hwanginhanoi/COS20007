using System;

namespace MainClock;

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
