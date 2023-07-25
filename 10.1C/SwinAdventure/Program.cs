namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine("You have arrived in the Hallway\n");

            string name = "";
            while (name == "")
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();

                if (name == "")
                {
                    Console.WriteLine("Invalid input. Please try again.\n");
                }
            }

            Console.WriteLine("\nPlayer's name: " + name);


            string desc = "";
            while (desc == "")
            {
                Console.WriteLine("Enter description: ");
                desc = Console.ReadLine();

                if (desc == "")
                {
                    Console.WriteLine("Invalid input. Please try again.\n");
                }
            }

            Console.WriteLine("\nPlayer's description: " + desc);

            Player player = new(name, desc);

            Item paper = new Item(new string[] { "Paper" }, "a paper", "This is a paper");
            Item pen = new Item(new string[] { "Pen" }, "a pen", "This is a pen");
            Item eraser = new Item(new string[] { "Eraser" }, "an eraser", "This is an eraser");
            Item pencil = new Item(new string[] { "Pencil" }, "a pencil", "This is a pencil");


            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");

            player.Inventory.Put(paper);
            player.Inventory.Put(pen);
            player.Inventory.Put(eraser);
            player.Inventory.Put(bag);

            bag.Inventory.Put(paper);

            Location location = new Location( new string[]{"Myroom"},"My Room", "Initial room");
            player.Location = location;



            Location northroom = new Location(new string[] { "Northroom" },"Northroom", "North");

            Location southroom = new Location(new string[] { "Southroom" },"Southroom", "South");


            Path southroomtolocation = new Path(new string[] { "south" }, "Door", "Travel through door", northroom, location);
            Path locationtonorthroom = new Path(new string[] { "north" }, "Door", "Travel through door", location, northroom);

            southroom.AddPath(southroomtolocation);
            location.AddPath(locationtonorthroom);


            Path locationtosouthroom = new Path(new string[] { "north" }, "Door", "Travel through door", location, southroom);
            Path northroomtolocation = new Path(new string[] { "south" }, "Door", "Travel through door", northroom, location);
            location.AddPath(locationtosouthroom);
            northroom.AddPath(northroomtolocation);

            location.Inventory.Put(pencil);


            string input = "";

            Command look = new LookCommand();
            Command move = new Move();

            CommandProcessor cmdprocessor = new CommandProcessor();

            while (true)
            {
                Console.Write("Command -> ");
                input = Console.ReadLine();

                string[] inputWords = input.ToLower().Split();

                if (inputWords[0] == "quit")
                {
                    break;
                }
                else if (inputWords[0] == "move")
                {
                    Console.WriteLine(move.Execute(player, input.ToLower().Split()));
                }
                else if (inputWords[0] == "look")
                {
                    Console.WriteLine(look.Execute(player, input.ToLower().Split()));
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }

}