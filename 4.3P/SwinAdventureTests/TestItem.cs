using SwinAdventure;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TestItem
    {
        Item itemTest;
        String testShortDescription;

        [SetUp]
        public void Setup()
        {
            itemTest = new(new string[] { "item" }, "item", "something");
            testShortDescription = "a item (item)";
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.That(itemTest.AreYou("item"), Is.True);
        }

        [Test]
        public void TestItemShortDescription()
        {
            Assert.That(itemTest.ShortDescription, Is.EqualTo(testShortDescription));
        }

        [Test]
        public void TestItemFullDescription()
        {
            Assert.That(itemTest.FullDescription, Is.EqualTo("something"));
        }
    }
}
