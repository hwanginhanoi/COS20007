using System;

namespace MainClock
{
    public class Clock
    {
        private Counter _hour;
        private Counter _min;
        private Counter _sec;

        public Clock()
        {
            _hour = new Counter("Hour");
            _min = new Counter("Min");
            _sec = new Counter("Sec");

        }

        public void Tick()
        {
            if (_sec.Ticks == 59)
            {
                _sec.Reset();
                if (_min.Ticks == 59)
                {
                    _min.Reset();
                        if (_hour.Ticks == 23)
                    {
                        _hour.Reset();
                    }
                    else
                    {
                        _hour.Increment();
                    }
                }
                else
                {
                    _min.Increment();
                }
            }
            else
            {
                _sec.Increment();
            }

        }

        public string Time
        {
            get
            {
                return $"{_hour.Ticks:00}:{_min.Ticks:00}:{_sec.Ticks:00}";
            }
        }

    }
}

