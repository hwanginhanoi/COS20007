using System;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {
        }

        public string ItemList
        {
            get {
                string list = "";
                foreach (Item itm in _items)
                {
                    list += "\t" + "a " + itm.Name + " " + "(" + itm.FirstId + ")\n";
                };
                return list;
            }
        }

        public Item? Fetch(string id) 
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public void Put(Item item) 
        {
            _items.Add(item);
        }

        public Item Take(string id) 
        {
            Item item = Fetch(id);

            if(_items != null)
            {
                _items.Remove(item);
                return item;
            }
            return null; 
        }

        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
