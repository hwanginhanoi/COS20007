using SwinAdventure;

namespace Test
{
    [TestFixture]
    public class TestBag
    {
        Bag bag1, bag2;
        Inventory inventoryTest;
        Item penTest, pencilTest, bottleTest;

        [SetUp]
        public void Setup()
        {
            bag1 = new(new string[] { "bag1" }, "bag1", "a bag1");
            bag2 = new(new string[] { "bag2" }, "bag2", "a bag2");

            inventoryTest = new();
            penTest = new(new string[] { "pen" }, "pen", "paper");
            pencilTest = new(new string[] { "pencil" }, "pencil", "eraser");
            bottleTest = new(new string[] { "bottle" }, "bottle", "water");

            bag1.Inventory.Put(penTest);
            bag1.Inventory.Put(pencilTest);

            bag2.Inventory.Put(bottleTest);
        }

        [Test]
        public void TestLocateItems()
        {
            Assert.Multiple(() => {

                Assert.That(bag1.Locate("pen"), Is.EqualTo(penTest));
                Assert.That(bag1.Locate("pencil"), Is.EqualTo(pencilTest));

                Assert.IsTrue(bag1.Inventory.HasItem("pen"));
                Assert.IsTrue(bag1.Inventory.HasItem("pencil"));
            });
        }

        [Test]
        public void TestLocateSelf()
        {
            Assert.That(bag1, Is.EqualTo(bag1.Locate("bag1")));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(bag1.Locate("randomitem123"), Is.EqualTo(null));
        }

        [Test]
        public void TestBagFullDescription()
        {
            string testBagDescription = $"In the {bag1.Name} you can see\n{bag1.Inventory.ItemList}";
            Assert.That(bag1.FullDescription, Is.EqualTo(testBagDescription));
        }

        [Test]
        public void TestBagInBag()
        {
            bag1.Inventory.Put(bag2);

            Assert.Multiple(() => {
                Assert.That(bag1.Locate("bag2"), Is.EqualTo(bag2));

                Assert.That(bag1.Locate("pen"), Is.EqualTo(penTest));
                Assert.That(bag1.Locate("pencil"), Is.EqualTo(pencilTest));

                Assert.That(bag1.Locate("bottle"), Is.EqualTo(null));
            });
        }
    }
}