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

		public String Level1() {
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
						} else if ( r == 7 && c == 4) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 8 && c > 10) {
						worldGrid [c, r].wall = true;
					}
					if (r == 9 && (c >= 1 && c < 10 && c > 10)) {
						if (c < 3 || (c > 3 && c < 12) || c == 18) {
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
						if (c == 2 || (c > 8 && c < 12) || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 11 && c >= 2) {
						if (c == 2 || c == 18) {
							worldGrid [c, r].wall = true;
						} else if (c == 9) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else {
							worlGrid [c, r].floor = true;
						}
					}
					if ((r == 12 || r == 13) && c >= 2) {
						if (c == 2 || (c > 8 && c < 12) || c == 18) {
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
						if (c == 4 || (c >=7 && c <= 12) || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 17 && c <= 16) {
						if (c == 4 || (c > 6 && c < 13) || c == 15) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
 				
				}
			return "1,3";
			}
					
				
					
			
		}
				
	}
}

