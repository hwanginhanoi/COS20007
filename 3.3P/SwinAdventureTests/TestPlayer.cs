using SwinAdventure;

namespace Test
{
    [TestFixture]
    public class TestPlayer
    {
        Player playerTest;
        Inventory inventoryTest;
        Item item1Test, item2Test;
        string testDescription;

        [SetUp]
        public void Setup()
        {
            playerTest = new("hoang", "The myth");
            inventoryTest = new();
            item1Test = new(new string[] { "item1" }, "item1", "new");
            item2Test = new(new string[] { "item2" }, "item2", "old");

            playerTest.Inventory.Put(item1Test);
            playerTest.Inventory.Put(item2Test);

            testDescription = $"You are hoang The myth.\nYou are carrying\n{playerTest.Inventory.ItemList}";
        }

        //! Checks the player can identify itself
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(playerTest.AreYou("me"));
        }

        [Test]
        public void TestPlayerisLocatable()
        {
            Assert.That(playerTest, Is.EqualTo(playerTest.Locate("me")));
            Assert.That(playerTest, Is.EqualTo(playerTest.Locate("inventory")));
        }

        [Test]
        public void TestLocateItems()
        {
            Assert.Multiple(()=>{
                Assert.That(playerTest.Locate("item1"), Is.EqualTo(item1Test));
                Assert.That(playerTest.Locate("item2"), Is.EqualTo(item2Test));

                Assert.That(playerTest.Inventory.HasItem("item1"), Is.True);
                Assert.That(playerTest.Inventory.HasItem("item2"), Is.True);
            });
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(playerTest.Locate("random"), Is.EqualTo(null));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(playerTest.FullDescription, Is.EqualTo(testDescription));
        }
    }
}
