using System;
using System.Collections;
namespace SoulLand
{
	[Serializable]
	public class World
	{
		public ArrayList mobs = new ArrayList ();
		public Tile[,] worldGrid;
		public World(int x, int y)
		{
			worldGrid = new Tile[y,x];
				
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			//temp

			for (int i = 0; i < 10; i++) {
				worldGrid [i, 0].wall = true;
			}

			for (int i = 0; i < 10; i++) {
				worldGrid [0, i].wall = true;
			}
			worldGrid [20, 10].door = true;
			worldGrid [20, 10].SetKeypass ("diddle");
			worldGrid [6, 8].item = new Key ("RIP","diddle");

			mobs.Add (new Mob(3,5));
			mobs.Add (new Mob(3,4));
			mobs.Add (new Mob(3,3));

			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
		}


	}
}

