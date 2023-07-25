using SwinAdventure;

namespace Test
{
    public class LookCommandTest
    {
        Command look;
        Player player, player1;
        Bag bag;

        Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("Hoang", null); 
            bag = new Bag(new string[] { "bag" },
                $"Hoang's bag",
                $"This is {player.FirstId} bag"); 
            player.Inventory.Put(bag);


            player1 = new Player("Hoang", "Player");

        }

        [Test]
        public void TestLookAtMe()
        {
            string Output = look.Execute(player, new string[] { "look", "at", "inventory" });
            string TestOutput = $"You are {player.Name} .\nYou are carrying\n{player.Inventory.ItemList}";
            Assert.That(Output, Is.EqualTo(TestOutput));
            Console.WriteLine(Output);
        }

        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);

            string Output = look.Execute(player, new string[] { "look", "at", "gem" });
            string TestOutput = $"{gem.FullDescription}";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestLookAtUnk()
        {
            string Output = look.Execute(player, new string[] { "look", "at", "gem" });
            string TestOutput = $"Couldn't find gem";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            player.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "gem", "in", "me" });
            string TestOutput = $"{gem.FullDescription}";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "gem", "in", $"bag" });
            string TestOutput = $"{gem.FullDescription}";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            bag.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "iron", "in", $"bag" });
            string TestOutput = $"Couldn't find iron";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            player1.Inventory.Put(bag);
            string Output = look.Execute(player1, new string[] { "look", "at", "gem", "in", $"{player.FirstId}" });
            string TestOutput = $"Couldn't find gem";
            Assert.That(Output, Is.EqualTo(TestOutput));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(look.Execute(player1, new string[] { "find", "gem" }), Is.EqualTo("Error in look input"));
        }

    }
}