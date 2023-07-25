using System;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _desc;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _desc = desc;
        }

        public string Name
        {
            get { return _name.ToLower(); }
        }

        public string ShortDescription
        {
            get
            {
                return "a " + _name + " " + "(" + FirstId + ")".ToLower(); 
            }
        }

        public virtual string FullDescription
        {
            get { return _desc; }
        }
    }
}
