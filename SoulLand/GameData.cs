using System;

namespace SoulLand
{
	[Serializable]
	public class GameData
	{
		public Player player;
		public Inventory inv;
		public World world;
		public GameData ()
		{

			player = new Player();
			inv = new Inventory();
			world = new World (40, 40);
		}
	}
}

