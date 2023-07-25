namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        private Location _location;

        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
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
            if (AreYou(id))
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }

        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public void Move(Path path)
        {
            if (path.Destination != null)
            {
                _location = path.Destination;
            }
        }
    }
}
