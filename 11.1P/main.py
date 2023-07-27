from time import sleep


class Counter:
    def __init__(self, name):
        self._name = name
        self._count = int(0)

    def reset(self):
        self._count = 0

    def increment(self):
        self._count += 1

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def tick(self):
        return self._count


class Clock:
    def __init__(self):
        self._hour = Counter("Hour")
        self._min = Counter("Min")
        self._sec = Counter("Sec")

    def tick(self):
        if self._sec.tick == 59:
            self._sec.reset()
            if self._min.tick == 59:
                self._min.reset()
                if self._hour.tick == 59:
                    self._hour.reset()
                else:
                    self._hour.increment()
            else:
                self._min.increment()
        else:
            self._sec.increment()

    @property
    def time(self):
        return str(str(self._hour.tick) + ":" + str(self._min.tick) + ":" + str(self._sec.tick))


class Main:
    clock = Clock()

    for x in range(86401):
        clock.tick()
        print(clock.time)
        sleep(0.001)


Main()
