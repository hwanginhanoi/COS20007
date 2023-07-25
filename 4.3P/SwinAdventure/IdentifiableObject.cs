using System;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] ids)
        {
            _identifiers.AddRange(ids);
        }

        public List<string> Identifiers
        {
            get
            {
                return _identifiers;
            }
            set
            {
                _identifiers = value;
            }
        }

        public bool AreYou(string id)
        {
            foreach (string identifier in _identifiers)
            {
                if (identifier.ToLower() == id.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public string FirstId
        {
            get
            {
                return _identifiers.First();
            }
        }

        public void AddId(string id)
        {
            id = id.ToLower();
            Identifiers.Add(id);
        }
    }
}
