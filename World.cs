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
			case 3:
				return Level3 ();
			case 4:
				return Level4 ();
			case 5:
				return Level5 ();
			default:
				return Level1 ();
			}

		}

		public String Level1() {
			worldGrid = new Tile[22, 22];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
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
							mobs.Add (new Mob (c, r));
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
					if (r == 9 && c <= 16) {
						if (c == 6) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 4) {
							mobs.Add (new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 0 || (c >= 12 && c <= 14) || c == 16) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 10 && (c <= 12 || (c >= 14 && c <= 16))) {
						if (c == 5) {
							worldGrid [c, r].item = new Key ("Key 2", "Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 10) {
							mobs.Add (new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c == 6 || c == 12 || c == 14 || c == 16) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}	
					}
					if (r == 11 && (c <= 12 || (c >= 14 && c <= 16))) {
						if (c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					}
					if (r == 12 && (c >= 14 && c <= 16)) {
						if (c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					}
					if (r == 13 && (c >= 10 && c <= 20)) {
						if (c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					}
					if ((r == 14 || r == 20) && (c >= 10 && c <= 20)) {
						if (c == 10 || c == 20) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if ((r == 15 || r == 19) && (c >= 6 && c <= 20)) {
						if (c >= 11 && c <= 19) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					}
					if ((r == 16 || r == 18) && (c >= 6 && c <= 20)) {
						if (c == 6 || c == 10 || c == 20) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 17 && (c >= 6 && c <= 20)) {
						if (c == 10) {
//							worldGrid [c, r].door = true;
//							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else if (c == 6 || c == 20) {
							worldGrid [c, r].wall = true;
						} else if (c == 7) {
							worldGrid [c, r].end = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 21 && (c >= 10 && c <= 20)) {
						worldGrid [c, r].wall = true;
					}

				}
			}
			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
			return "7,2";
		}

		public String Level2() {
			worldGrid = new Tile[19, 23];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (c == 0 && (r >= 17 && r <= 22)) {
						worldGrid [c, r].wall = true;
					}
					if (c == 1 && ((r >= 0 && r <= 9) || (r >= 17 && r <= 22))) {
						if (r == 20) {
							mobs.Add (new Mob (c, r));
							worldGrid [c, r].floor = true;
						} else if ((r >= 1 && r <= 8) || (r <= 18 && r >= 21)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (c == 2 (r >= 0 && r <= 22)) {
						if (r == 9) {
							
						}
					}


				}
			}
		
		
		}
		
		
	}				
}

