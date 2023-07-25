﻿namespace SwinAdventure
{
    public class Path : GameObject
    {
        bool _isBlocked;

        Location _source, _destination;

        public Path(string[] ids, string name, string desc, Location source, Location destination) : base(ids, name, desc)
        {
            _source = source;
            _destination = destination;
            _isBlocked = false;

            AddId("path");
            foreach (string s in name.Split(" "))
            {
                AddId(s);
            }
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public override string ShortDescription
        {
            get
            {
                return Name;
            }
        }

        public bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                _isBlocked = value;
            }
        }

    }
}

