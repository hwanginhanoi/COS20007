using Swin_adventure;

namespace IdentifiableObjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAreYou()
        {

            identifiableObject id = new identifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(true, id.AreYou("fred"));
        }
        [TestMethod]
        public void TestNotAreYou()
        {
            identifiableObject id = new identifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(false, id.AreYou("hoang"));
        }

        [TestMethod]
        public void TestCaseSensitive()
        {
            identifiableObject id = new identifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(true, id.AreYou("fReD"));
        }

        [TestMethod]
        public void TestFirstId()
        {

            identifiableObject id = new identifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual("fred", id.FirstId);
        }

        [TestMethod]
        public void TestFirstIdWithNoId()
        {
            identifiableObject id = new identifiableObject(new string[] { });
            Assert.AreEqual("", id.FirstId);
        }

        [TestMethod]
        public void TestAddId()
        {

            identifiableObject id = new identifiableObject(new string[] { "fred", "bob" });
            id.AddId("Hoang");
            Assert.AreEqual(true, id.AreYou("Tuan"));
        }
    }
}