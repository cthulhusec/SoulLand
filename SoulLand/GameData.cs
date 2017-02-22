using System;

namespace SoulLand
{
	[Serializable]
	public class GameData
	{
		public Player player;
		public Inventory inv;
		public World world;
		public bool load;

        public float audioVolume = 1;

		public GameData ()
		{
			load = false;
			player = new Player();
			inv = new Inventory();
			world = null;
		}
	}
}

