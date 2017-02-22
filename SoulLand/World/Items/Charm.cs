using System;

namespace SoulLand
{
	[Serializable]
	public class Charm : Item
	{
        public bool selectable = true;


		public Charm (String n) : base(n)
		{

		}
	}
}

