using System;

namespace SoulLand
{
	[Serializable]
	public class GameData
	{
		public Player player;
		public Inventory inv;
		public GameData ()
		{

			player = new Player();
			inv = new Inventory();
		}
	}
}

