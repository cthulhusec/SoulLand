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
					return level3 ();
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
					if (r == 9 && c <= 16) {
						if (c == 6) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 4) {
							mobs.Add (new Mob (r, c));
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
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c == 6 || c == 12 || c == 16) {
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
					if (r == 13 && c >= 10) {
						if (c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					} 
					if ((r == 14 || r == 20) && c >= 10) {
						if (c == 10 || c == 20) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if ((r == 15 || r == 19) && c >= 6) {
						if (c >= 11 && c <= 19) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;	
						}
					}
					if ((r == 16 || r == 18) && c >= 6) {
						if (c == 6 || c == 10 || c == 20) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 17 && c >= 6) {
						if (c == 10) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else if (c == 6 || c == 20) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 21 && c >= 10) {
						worldGrid [c, r].wall = true;
					}
					
				}
			}

			return "7,2";
		}

		public String Level2() {
			worldGrid = new Tile[23, 19];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int r = 0; r < worldGrid.GetLength (0); r++) {
				for (int c = 0; c < worldGrid.GetLength (1); c++) {
					if (r == 0 && (c >= 1 && c <= 5))  {
						worldGrid [c, r].wall = true;
					}
					if ((r >= 1 && r <= 8) && (c >= 1 && c <= 5)) {
						if (c == 1 || c == 5) {
							worldGrid [c, r].wall = true;
						} else if (r == 4 && c == 2) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (r == 5 && c == 4) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (r == 7 && c == 2) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (r == 8 && c == 4) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 8 && c >= 11) {
						worldGrid [c, r].wall = true;
					}
					if (r == 9 && (c >= 1 && c <= 9 && c >= 11)) {
						if (c =< 2 || (c >= 4 && c <= 11) || c == 18) {
							worldGrid [c, r].wall = true;
						} else if (c == 3) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;	
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 10 && c >= 2) {
						if (c == 6 || c == 14) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (c == 2 || (c >= 9 && c <= 11) || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 11 && c >= 2) {
						if (c == 2 || c == 18) {
							worldGrid [c, r].wall = true;
						} else if (c == 16) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (c == 9) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else {
							worlGrid [c, r].floor = true;
						}
					}
					if ((r == 12 || r == 13) && c >= 2) {
						if (r == 13 && (c == 6 || c == 13) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if (c == 2 || (c >= 9 && c <= 11) || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 14 && c >= 2) {
						if (c == 4 || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid[c, r].wall = true;
						}
					}
					if ((r == 15 && (c >= 3 && c <= 16)) {
						if (c == 4 || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid[c, r].wall = true;
						} 
					}
					if (r == 16 && (c >= 3 && c <= 16)) {
						if (c == 4 || (c >= 7 && c <= 12) || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 17 && c <= 16) {
						if (c == 4 || (c >= 7 && c <= 12) || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && c <= 16) {
						if ((c >= 1 && c <= 4) || (c >= 7 && c <= 15)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 19 && c <= 16) {
						if ((c >= 1 && c <= 4) || (c >= 7 && c <= 12)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 20) {
						if (c == 13) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else if (c == 2) {
							mobs.Add (new Mob (r, c));
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 4) || (c >= 7 && c <= 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 21) {
						if (c == 1) {
							worldGrid [c, r].item = new Key ("Key 2", "Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c == 5 || c == 6 || c == 13 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 22) {
						worldGrid [c, r].wall = true;
					}
				}
			}
							   
			return "1,3";
		}
							   
		public String Level3() {
			worldGrid = new Tile[];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
	}				
}

