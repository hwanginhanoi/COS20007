using System;
using SplashKitSDK;

namespace Swin_adventure
{
    class IdentifiableObject
    {
        private static readonly List<string> list = new List<string>(2);
        private List<string> _identifiers = list;

        public IdentifiableObject(string[] idents)
        {
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        public bool AreYou(string id)
        {
            bool res = false;
            for (int i = 0; i < _identifiers.Count(); i++)
            {
                if (_identifiers[i] == id.ToLower())
                {
                    res = true;
                }
            }
            return res;
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];

                }
                else
                {
                    return "";
                }
            }
        }

        public void AddId(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
    public class Program
    {
        public static void Main()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            IdentifiableObject id2 = new IdentifiableObject(new string[] { });
            Console.WriteLine(id.AreYou("Tuan"));
            Console.WriteLine(id.AreYou("Hoang"));
            Console.WriteLine(id.AreYou("fred"));
            Console.WriteLine(id.FirstId);
            Console.WriteLine(id2.FirstId);
            id.AddId("Tuan");
            Console.WriteLine(id.AreYou("Tuan"));
            Console.ReadKey();
        }
    }
}
