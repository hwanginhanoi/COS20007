using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace SwinAdventure
{
	public class LookCommand : Command
	{
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string itemID;
            IHaveInventory container;

            if (text[0] != "look")
                return "Error in look input";

            switch (text.Length){

                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at";
                    container = p;
                    itemID = text[2];
                    break;

                case 5:
                    container = FetchContainer(p, text[4]);
                    if (text[3].ToLower() != "in")
                        return "What do you want to look in";
                    itemID = text[2];
                    break;

                default:
                    return "I don’t know how to look like that";
            }

            return LookAtIn(itemID, container);

        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).FullDescription;

            return "Couldn't find " + thingId;
        }
    }
}

