using System;

namespace SoulLand
{
	[Serializable]
	public class Key : Item
	{
		public string keyPass = "null";
        public bool selectable = false;

        public Key (String n, String pass) : base(n)
		{
			keyPass = pass;
		}
	}
}

