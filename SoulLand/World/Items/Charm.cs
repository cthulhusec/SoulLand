using System;

namespace SoulLand
{
	[Serializable]
	public class Charm : Item
	{
        public int Type;
        public bool selectable = true;


		public Charm (String n, int tempType) : base(n)
		{
            Type = tempType;
		}
	}
}

