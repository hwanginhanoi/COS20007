using SwinAdventure;

namespace Test
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        [Test]
        public void TestAreYou()
        {

            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(id.AreYou("fred"), Is.EqualTo(true));
        }
        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(id.AreYou("hoang"), Is.EqualTo(false));
        }

        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(id.AreYou("fReD"), Is.EqualTo(true));
        }

        [Test]
        public void TestFirstId()
        {

            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(id.FirstId, Is.EqualTo("fred"));
        }

        [Test]
        public void TestFirstIdWithNoId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] {"", "something" });
            Assert.That(id.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddId()
        {

            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddId("Hoang");
            Assert.That(id.AreYou("Hoang"), Is.EqualTo(true));
        }
    }
}