using SwinAdventure;

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

            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");

            player.Inventory.Put(paper);
            player.Inventory.Put(pen);
            player.Inventory.Put(eraser);
            bag.Inventory.Put(paper);

            string input = "";
            Command look = new LookCommand();

            while (true)
            {
                Console.Write("Command -> ");
                input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(look.Execute(player, input.ToLower().Split()));
                }

            }
        }
    }

}