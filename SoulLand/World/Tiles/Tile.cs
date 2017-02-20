using System;
namespace SoulLand
{
	[Serializable]
	public class Tile
	{
		public bool trigger = false;

		public int renderable = 0;
		
		public bool floor = false;

		public bool wall = false;

		public bool door = false;

		public bool end = false;

		private string keypass = "";

		public Item item;

		public Mob mob;

		public Boss boss;

		public Tile()
		{
		}


		public void OpenDoor (Inventory inv)
		{
			if (inv.UseKey (keypass)) {
				door = false;
			}

		}

		public void SetKeypass(String key)
		{
			keypass = key;
		}

	}
}

