using NUnit.Framework;
using SwinAdventure;

namespace Test
{
    public class PathTest
    {
        Player? playerTest;
        Location? room1;
        Location? room2;
        SwinAdventure.Path? pathTest;

        [Test]
        public void PathLocationTest()
        {
            playerTest = new Player("Hoang", "The Myth");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "Place", "Test place", room1, room2);
            room1.AddPath(pathTest);

            Location expected = room2;
            Location actual = pathTest.Destination;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PathNameTest()
        {
            playerTest = new Player("Hoang", "The Myth");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "Place", "Test place", room1, room2);
            room1.AddPath(pathTest);

            string expected = "Test place";
            string actual = pathTest.FullDescription;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLocatePath()
        {
            playerTest = new Player("Danny", "The Player!");

            room1 = new Location(new string[] { "Room 1" }, "Room 1", "This is room 1");
            room2 = new Location(new string[] { "Room 2" }, "Room 2", "This is room 2");

            playerTest.Location = room1;
            pathTest = new SwinAdventure.Path(new string[] { "south" }, "Place", "Test place", room1, room2);
            room1.AddPath(pathTest);

            GameObject expected = room1.Locate("south");
            GameObject actual = pathTest;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

