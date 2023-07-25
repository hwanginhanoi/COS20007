using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            Message? greetings = null;
            Message[] messages = {new Message("Welcome back!"),
                                new Message("What a lovely name"),
                                new Message("Great name"),
                                new Message("Oh hi!"),
                                new Message("That is a silly name")
                                };
            string? name;

            greetings = new Message("Hello World - from Message Object");
            greetings?.Print();


            while (true)
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }
                if (name?.ToLower() == "stop")
                {
                    break;
                }
                if (name?.ToLower() == "hoang")
                {
                    messages?[0].Print();
                }
                else if (name?.ToLower() == "hwang")
                {
                    messages?[1].Print();
                }
                else if (name?.ToLower() == "hoag")
                {
                    messages?[2].Print();
                }
                else if (name?.ToLower() == "hwag")
                {
                    messages?[3].Print();
                }
                else
                {
                    messages?[4].Print();
                }
            }


        }
    }
}
