using SwinAdventure;

namespace Test
{
    [TestFixture]
    public class TestInventory
    {
        Inventory inventoryTest;
        Item item1, item2;
        string testList;

        [SetUp]
        public void Setup()
        {
            inventoryTest = new();
            item1 = new(new string[] { "item1" }, "something", "new");
            item2 = new(new string[] { "item2" }, "something", "old");

            inventoryTest.Put(item1);
            inventoryTest.Put(item2);

            testList = $"\t{item1.ShortDescription}\n\t{item2.ShortDescription}\n";
        }

        [Test]
        public void TestFindItem()
        {
            Assert.Multiple(() =>{
                Assert.That(inventoryTest.HasItem("item1"), Is.True);
                Assert.That(inventoryTest.HasItem("item2"), Is.True);
            });
        }

        [Test]
        public void TestNoFoundItem()
        {
                Assert.That(inventoryTest.HasItem("?"), Is.False);
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.Multiple(()=>{
                Assert.That(item1, Is.EqualTo(inventoryTest.Fetch("item1")));
                Assert.That(item2, Is.EqualTo(inventoryTest.Fetch("item2")));

                Assert.That(inventoryTest.HasItem("item1"), Is.True);
                Assert.That(inventoryTest.HasItem("item2"), Is.True);
            });
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.Multiple(() => {
                Assert.That(item1, Is.EqualTo(inventoryTest.Take("item1")));
                Assert.That(item2, Is.EqualTo(inventoryTest.Take("item2")));

                Assert.That(inventoryTest.HasItem("item1"), Is.False);
                Assert.That(inventoryTest.HasItem("item2"), Is.False);
            });
        }

        [Test]
        public void TestItemList()
        {
            Assert.That(testList, Is.EqualTo(inventoryTest.ItemList));
        }
    }
}
