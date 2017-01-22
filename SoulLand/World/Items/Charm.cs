using System;

namespace SoulLand
{
	[Serializable]
	public class Charm : Item
	{
		public int RangedDamage;
		public int MeleeDamage;


		public Charm (String n, int r, int m) : base(n)
		{
			RangedDamage = r;
			MeleeDamage = m;
		}
	}
}

