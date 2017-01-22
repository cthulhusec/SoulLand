using System;

namespace SoulLand
{
	[Serializable]
	public class Mob
	{
		public int health;
		public int posx = 0;
		public int posy = 0;
		public Mob (int tempX, int tempY)
		{
			posx = tempX;
			posy = tempY;
		}
	}
}

