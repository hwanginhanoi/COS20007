using SwinAdventure;

namespace Test
{
    [TestFixture]
    public class TestLocation
    {
        Location location1, location2;
        Inventory inventoryTest;
        Item penTest, pencilTest, bottleTest;

        [SetUp]
        public void Setup()
        {
            location1 = new(new string[] { "location1" }, "location1", "a location1");
            location2 = new(new string[] { "location2" }, "location2", "a location2");

            inventoryTest = new();
            penTest = new(new string[] { "pen" }, "pen", "paper");
            pencilTest = new(new string[] { "pencil" }, "pencil", "eraser");
            bottleTest = new(new string[] { "bottle" }, "bottle", "water");

            location1.Inventory.Put(penTest);
            location1.Inventory.Put(pencilTest);

            location2.Inventory.Put(bottleTest);
        }

        [Test]
        public void TestItemInLocation()
        {
            Assert.Multiple(() => {

                Assert.That(location1.Locate("pen"), Is.EqualTo(penTest));
                Assert.That(location1.Locate("pencil"), Is.EqualTo(pencilTest));

                Assert.IsTrue(location1.Inventory.HasItem("pen"));
                Assert.IsTrue(location1.Inventory.HasItem("pencil"));
            });
        }

        [Test]
        public void TestOwnLocation()
        {
            Assert.That(location1, Is.EqualTo(location1.Locate("location1")));
        }

        [Test]
        public void TestNothingInLocation()
        {
            Assert.That(location1.Locate("randomitem123"), Is.EqualTo(null));
        }

        [Test]
        public void TestLocationInlocation()
        {
            location1.Inventory.Put(location2);

            Assert.Multiple(() => {
                Assert.That(location1.Locate("location2"), Is.EqualTo(location2));

                Assert.That(location1.Locate("pen"), Is.EqualTo(penTest));
                Assert.That(location1.Locate("pencil"), Is.EqualTo(pencilTest));

                Assert.That(location1.Locate("bottle"), Is.EqualTo(null));
            });
        }
    }
}