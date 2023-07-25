namespace SwinAdventure
{
    public class Bag : Item
    {
        Inventory _inventory = new();

        public Bag(string[] idents, string name, string description) : base(idents, name, description)
        {

        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get { return $"In the {Name} you can see\n{_inventory.ItemList}"; }
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
