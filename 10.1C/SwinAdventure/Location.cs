namespace SwinAdventure
{
    public class Location : Item, IHaveInventory
    {
        Inventory _inventory = new();
        List<Path> _paths;


        public Location(string[] strings, string name, string desc) : base(new string[] { "location" }, name, desc)
        {
            _inventory = new Inventory();
 
            _paths = new List<Path>();
        }


        public Location(string name, string desc, List<Path> paths) : base(new string[] { "location" } ,name, desc)
        {
            _paths = paths;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get { return $"You are currently in {Name}\nIn here you can see\n{_inventory.ItemList}"; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return _inventory.Fetch(id);
        }

        public string PathList
        {
            get
            {
                string list = string.Empty + "\n";

                if (_paths.Count == 1)
                {
                    return "There is an exit " + _paths[0].FirstId + ".";
                }

                list = list + "There are exits to the ";

                for (int i = 0; i < _paths.Count; i++)
                {
                    if (i == _paths.Count - 1)
                    {
                        list = list + "and " + _paths[i].FirstId + ".";
                    }
                    else
                    {
                        list = list + _paths[i].FirstId + ", ";
                    }
                }

                return list;
            }
        }

        public string V1 { get; }
        public string V2 { get; }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
    }
}


