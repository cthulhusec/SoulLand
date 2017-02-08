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
		public Boolean Within(Player player) {
			if (player.posx - posx < 8 && player.posx - posx > - 8 && player.posy - posy < 8 && player.posy - posy > -8) {
				return true;
			}
			return false;
		}
	}
}

