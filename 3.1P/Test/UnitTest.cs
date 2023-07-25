using MainClock;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TestCounter
    {
        [Test]
        public void TestInitialize()
        {
            Counter test = new Counter("Test Counter");

            Assert.That(test.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void TestIncrement()
        {
            Counter test = new Counter("Test Counter");

            test.Increment();

            Assert.That(test.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void TestMultipleIncrements()
        {
            Counter test = new Counter("Test Counter");

            test.Increment();
            test.Increment();

            Assert.That(test.Ticks, Is.EqualTo(2));
        }

        [Test]
        public void TestReset()
        {
            Counter test = new Counter("Test Counter");

            test.Increment();

            test.Reset();

            Assert.That(test.Ticks, Is.EqualTo(0));
        }
    }


    public class TestClock
    {
        [Test]
        public void TestSingleIncrement()
        {
            Clock test = new Clock();
            
            test.Tick();           

            Assert.That(test.Time, Is.EqualTo("00:00:01"));
        }

        [Test]
        public void TestMinuteIncrement()
        {
            Clock test = new Clock();

            for (int i = 0; i < 61; i++)
            {
                test.Tick();
            }

            Assert.That(test.Time, Is.EqualTo("00:01:01"));

        }

        [Test]
        public void TestHourIncrement()
        {
            Clock test = new Clock();

            for (int i = 0; i < 3661; i++)
            {
                test.Tick();
            }

            Assert.That(test.Time, Is.EqualTo("01:01:01"));
        }

        [Test]
        public void TestResetAll()
        {
            Clock test = new Clock();

            for (int i = 0; i < 86400; i++)
            {
                test.Tick();
            }

            Assert.That(test.Time, Is.EqualTo("00:00:00"));
        }
    }
}

