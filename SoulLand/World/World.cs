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
		}

		public String ChangeLevel(int i) { 
			switch (i) {
				case 1:
					return Level1 ();
				case 2:
					return Level2 ();
				default:
					return Level1 ();
			}

		}

		public String Level1() {
			worldGrid = new Tile[21, 22];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}

			for (int r = 0; r < worldGrid.GetLength (0); r++) {
				for (int c = 0; c < worldGrid.GetLength (1); c++) {
					if (r == 0 && c <= 9) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && c <= 9) {
						if (c == 0 || c == 5 || c == 9) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 2 && c <= 9) {
						if (c == 0 || c == 9) {
							worldGrid [c, r].wall = true;
						} else if (c == 2) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 3 && c <= 9) {
						if (c == 0 || c == 5 || c == 9) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 4 && c <= 9) {
						if (c == 2) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 5 && (c >= 1 && c <= 3)) {
						if (c == 2) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 6 && c <= 12) {
						if (c == 2) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 7 && c <= 16) {
						if (c == 0 || c == 6 || (c >= 12 && c <= 16)) {
							worldGrid [c, r].wall = true;
						} else if (c == 10) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 8 && c <= 16) {
						if (c == 0 || c == 6 || c == 16) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
				}
			}

			return "7,2";
		}

		public String Level2() {
			for (int i = 0; i < 20; i++) {
				worldGrid [i, 0].wall = true;
			}

			for (int i = 0; i < 20; i++) {
				worldGrid [0, i].wall = true;
			}
			worldGrid [20, 11].end = true;
			worldGrid [20, 10].door = true;
			worldGrid [20, 10].SetKeypass ("diddle");
			worldGrid [6, 8].item = new Key ("RIP","diddle");

			mobs.Add (new Mob(3,5));
			mobs.Add (new Mob(3,4));
			mobs.Add (new Mob(3,3));

			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
			return "25,15";
		}
	}
}

