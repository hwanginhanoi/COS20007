using System;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        Inventory _inventory = new Inventory();
        public Player(string name, string desc)
            : base(new string[] {"me", "inventory"}, name, desc)
        {

        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription 
        {
            get { return $"You are {Name} {base.FullDescription}.\nYou are carrying\n{Inventory.ItemList}"; }
        }
        public GameObject Locate(string id) 
        {
            if (this.AreYou(id) == true)
            {
                return this; 
            }
            return _inventory.Fetch(id);
        }
    }
}
