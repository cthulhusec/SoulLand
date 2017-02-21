using System;
using System.Collections;
namespace SoulLand
{
	[Serializable]
	public class World
	{
		public Boss boss = null;
		public ArrayList mobs = new ArrayList ();
		public int triggerNo;
		public int currentLevel = 7;
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

        public void EmptyMobs()
        {
            mobs = new ArrayList();
        }

	public String ChangeLevel() {
            currentLevel++;
		switch (currentLevel) {
		case 1:
                    EmptyMobs();
                    return Level1 ();
		case 2:
                    EmptyMobs();
                    return Level2 ();
		case 3:
                    EmptyMobs();
                    return Level3 ();
		case 4:
                    EmptyMobs();
                    return Level4 ();
		case 5:
                    EmptyMobs();
                    return Level5 ();
		case 6:
                    EmptyMobs();
                    return Level6 ();
		case 7:
                    EmptyMobs();
                    return Level7 ();
		case 8:
			EmptyMobs ();
			return Level8 ();
		default:
                    EmptyMobs();
                    return Level1 ();
		}

	}

	public String Level1() {
            triggerNo = 0;
		worldGrid = new Tile[22, 22];

		for (int c = 0; c < worldGrid.GetLength (0); c++) {
			for (int r = 0; r < worldGrid.GetLength (1); r++) {
				worldGrid [c, r] = new Tile ();
			}
		}
		for (int r = 0; r < worldGrid.GetLength (0); r++) {
			for (int c = 0; c < worldGrid.GetLength (1); c++) {
			    if (r == 0 && c <= 9)
			    {
				worldGrid[c, r].wall = true;
			    }
			    if (r == 1 && c <= 9)
			    {
				if (c == 0 || c == 5 || c == 9)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 2 && c <= 9)
			    {
				if (c == 0 || c == 9)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 2)
				{
				    worldGrid[c, r].item = new Key("Key 1", "Lock1");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 3)
				{
				    worldGrid[c, r].floor = true;
				}
				else if (c == 4)
				{
				    worldGrid[c, r].trigger = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 3 && c <= 9)
			    {
				if (c == 0 || c == 5 || c == 9)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 4 && c <= 9)
			    {
				if (c == 2)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock1");
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 5 && (c >= 1 && c <= 3))
			    {
				if (c == 2)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 6 && c <= 12)
			    {
				if (c == 2)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 7 && c <= 16)
			    {
				if (c == 0 || c == 6 || (c >= 12 && c <= 16))
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 2)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 10)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 8 && c <= 16)
			    {
				if (c == 0 || c == 6 || c == 16)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 9 && c <= 16)
			    {
				if (c == 4)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (c == 6)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock2");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 7)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 0 || (c >= 12 && c <= 14) || c == 16)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 10 && (c <= 12 || (c >= 14 && c <= 16)))
			    {
				if (c == 5)
				{
				    worldGrid[c, r].item = new Key("Key 2", "Lock2");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 10)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (c == 0 || c == 6 || c == 12 || c == 14 || c == 16)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 11 && (c <= 12 || (c >= 14 && c <= 16)))
			    {
				if (c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 12 && (c >= 14 && c <= 16))
			    {
				if (c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 13 && (c >= 10 && c <= 20))
			    {
				if (c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if ((r == 14 || r == 20) && (c >= 10 && c <= 20))
			    {
				if (c == 10 || c == 20)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 15)
				{
				    worldGrid[c, r].trigger = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if ((r == 15 || r == 19) && (c >= 6 && c <= 20))
			    {
				if (c >= 11 && c <= 19)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if ((r == 16 || r == 18) && (c >= 6 && c <= 20))
			    {
				if (c == 6 || c == 10 || c == 20)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 17 && (c >= 6 && c <= 20))
			    {
				if (c == 6 || c == 20)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 8)
				{
				    worldGrid[c, r].item = new Charm("Double Attack Charm", 1);
				    worldGrid[c, r].floor = true;
				}
				else if (c == 7)
				{
				    worldGrid[c, r].end = true;
				}
				else if (c == 9)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 10)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock3");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 15)
				{ 
				    boss = new Boss(c, r, "Lock3");
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 21 && (c >= 10 && c <= 20))
			    {
				worldGrid[c, r].wall = true;
			    }
			    // Render
			    if ((r >= 0 && r <= 7) && (c >= 0 && c <= 4))
			    {
				if ((r >= 0 && r <= 1) || (r >= 3 && r <= 4))
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if (r == 2 && (c >= 0 && c <= 3))
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if ((r >= 5 && r <= 6) && (c >= 1 && c <= 3))
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if (r == 7 && c == 2)
				{
				    worldGrid[c, r].renderable = 1;
				}
			    }
			    if ((r >= 6 && r <= 11) && (c >= 0 && c <= 7))
			    {
				if (r == 6 && (c == 0 || (c >= 4 && c <= 6)))
				{
				    worldGrid[c, r].renderable = 2;
				}
				else if (r == 7 && ((c >= 0 && c <= 1) || (c >= 3 && c <= 6)))
				{
				    worldGrid[c, r].renderable = 2;
				}
				else if ((r == 8 || (r >= 10 && r <= 11)) && (c >= 0 && c <= 6))
				{
				    worldGrid[c, r].renderable = 2;
				}
				else if (r == 9 && (c >= 0 && c <= 7))
				{
				    worldGrid[c, r].renderable = 2;
				}
			    }
			    if ((r >= 6 && r <= 14) && (c >= 7 && c <= 16))
			    {
				if ((r >= 6 && r <= 8) || (r >= 10 && r <= 12))
				{
				    worldGrid[c, r].renderable = 3;
				}
				else if (r == 9 && (c >= 8 && c <= 16))
				{
				    worldGrid[c, r].renderable = 3;
				}
				else if (r == 13 && (c >= 14 && c <= 16))
				{
				    worldGrid[c, r].renderable = 3;
				}
				else if (r == 14 && c == 15)
				{
				    worldGrid[c, r].renderable = 3;
				}
			    }
			    if ((r >= 13 && r <= 21) && (c >= 10 && c <= 21))
			    {
				if (r == 13 && ((c >= 10 && c <= 13) || (c >= 17 && c <= 20)))
				{
				    worldGrid[c, r].renderable = 4;
				}
				else if (r == 14 && ((c >= 10 && c <= 14) || (c >= 16 && c <= 20)))
				{
				    worldGrid[c, r].renderable = 4;
				}
				else if (r >= 15 && r <= 21)
				{
				    worldGrid[c, r].renderable = 4;
				}
			    }
			    if ((r >= 15 && r <= 19) && (c >= 6 && c <= 9))
			    {
				worldGrid[c, r].renderable = 5;
			    }
                	}
		}
		foreach (Mob mob in mobs) {
                	worldGrid[mob.posx, mob.posy].mob = mob;
		}
           	 worldGrid[boss.posx, boss.posy].boss = boss;
			return "7,2";
		}
		public String Level2() {
			triggerNo = 0;
			worldGrid = new Tile[19, 23];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
			    if (r == 0 && (c >= 1 && c <= 5))
			    {
				worldGrid[c, r].wall = true;
			    }
			    if ((r >= 1 && r <= 8) && (c >= 1 && c <= 5))
			    {
				if (c == 1 || c == 5)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (r == 4 && c == 2)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (r == 5 && c == 4)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (r == 7 && c == 2)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (r == 8 && c == 4)
				{
				    worldGrid[c, r].item = new Key("Key 1", "Lock1");
				    worldGrid[c, r].floor = true;
				}
				else if (r == 8 && c >= 11)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 8 && c >= 11)
			    {
				worldGrid[c, r].wall = true;
			    }
			    if (r == 9 && (c >= 1 && c <= 9 || c >= 11))
			    {
				if (c <= 2 || (c >= 4 && c <= 11) || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 3)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock1");
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 10 && c >= 2)
			    {
				if (c == 6 || c == 14)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (c == 3)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 2 || (c >= 9 && c <= 11) || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 11 && c >= 2)
			    {
				if (c == 2 || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 9)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock2");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 10)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 16)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if ((r == 12 || r == 13) && c >= 2)
			    {
				if (r == 13 && (c == 6 || c == 13))
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (c == 2 || (c >= 9 && c <= 11) || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 14 && c >= 2)
			    {
				if (c == 4 || c == 15)
				{
				    worldGrid[c, r].trigger = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 15 && (c >= 3 && c <= 16))
			    {
				if (c == 4 || c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 16 && (c >= 3 && c <= 16))
			    {
				if (c == 4 || (c >= 7 && c <= 12) || c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 17 && c <= 16)
			    {
				if (c == 4)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if ((c >= 7 && c <= 12) || c == 15)
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 18 && c <= 16)
			    {
				if (c == 13)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if (c == 9)
				{
					boss = new Boss(c, r, "Lock3");
					worldGrid[c, r].floor = true;
				}
				else if ((c >= 1 && c <= 4) || (c >= 7 && c <= 15))
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 19 && c <= 18)
			    {
				if ((c >= 1 && c <= 4) || (c >= 7 && c <= 12))
				{
				    worldGrid[c, r].floor = true;
				}
				else
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 20 && c <= 18)
			    {
				if (c == 2)
				{
				    mobs.Add(new Mob(c, r));
				    worldGrid[c, r].floor = true;
				}
				else if (c == 13)
				{
				    worldGrid[c, r].door = true;
				    worldGrid[c, r].SetKeypass("Lock3");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 14)
				{
				    worldGrid[c, r].trigger = true;
				}
				else if ((c >= 1 && c <= 4) || (c >= 7 && c <= 17))
				{
				    worldGrid[c, r].floor = true;
				}
				else if (c == 0 || c == 5 || c == 6 || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
			    }
			    if (r == 21 && c <= 18)
			    {
				if (c == 1)
				{
				    worldGrid[c, r].item = new Key("Key 2", "Lock2");
				    worldGrid[c, r].floor = true;
				}
				else if (c == 0 || c == 5 || c == 6 || c == 13 || c == 18)
				{
				    worldGrid[c, r].wall = true;
				}
				else if (c == 17)
				{
				    worldGrid[c, r].end = true;
				}
				else
				{
				    worldGrid[c, r].floor = true;
				}
			    }
			    if (r == 22 && c <= 18)
			    {
				worldGrid[c, r].wall = true;
			    }
			    //Rederable
			    if ((r >= 9 && r <= 14) && (c >= 0 && c <= 10))
			    {
				if (r == 9 && (c >= 6 && c <= 9))
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if (r == 10 && (c == 2 || (c >= 4 && c <= 10)))
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if (r == 11 || r == 12)
				{
				    worldGrid[c, r].renderable = 1;
				}
				else if ((r >= 13 && r <= 14) && (c >= 0 && c <= 9))
				{
				    worldGrid[c, r].renderable = 1;
				}
			    }
			    if ((r >= 15 && r <= 17) && (c >= 3 && c <= 5))
			    {
				worldGrid[c, r].renderable = 2;
			    }
			    if ((r >= 17 && r <= 22) & (c >= 0 && c <= 5)) {
				if (r == 17 && (c >= 0 && c <= 2))
				{
				    worldGrid[c, r].renderable = 3;
				}
				else
				{
				    worldGrid[c, r].renderable = 3;
				}
			    }
			    if ((r >= 8 && r <= 14) && (c >= 10 && c <= 18))
			    {
				if (r == 8 || r == 9 || r == 13 || r == 14)
				{
				    worldGrid[c, r].renderable = 4;
				}
				else if ((r >= 10 && r <= 12) && (c >= 11 && c <= 18))
				{
				    worldGrid[c, r].renderable = 4;
				}
			    }
			    if ((r >= 15 && r <= 19) && (c >= 13 && c <= 16))
			    {
				if (r == 15 || r == 16)
				{
				    worldGrid[c, r].renderable = 5;
				}
				else if (r >= 17 && r <= 19)
				{
				    worldGrid[c, r].renderable = 5;
				}
			    }
			    if ((r >= 15 && r <= 22) && (c >= 6 && c <= 14))
			    {
				if ((r == 15 || r == 16 || r == 21 || r == 22) && (c >= 6 && c <= 13))
				{
				    worldGrid[c, r].renderable = 6;
				}
				else if ((r >= 17 && r <= 19) && (c >= 6 && c <= 12))
				{
				    worldGrid[c, r].renderable = 6;
				}
				else if (r == 20)
				{
				    worldGrid[c, r].renderable = 6;
				}
			    }
			    if ((r >= 19 && r <= 22) && (c >= 14 && c <= 18))
			    {
				if (r == 19 && (c == 17 || c == 18))
				{
				    worldGrid[c, r].renderable = 7;
				}
				else if (r == 20 && (c >= 15 && c <= 18))
				{
				    worldGrid[c, r].renderable = 7;
				}
				else if (r == 21 || r == 22)
				{
				    worldGrid[c, r].renderable = 5;
				}
			    }
               		}
		}
		foreach (Mob mob in mobs) {
			worldGrid[mob.posx, mob.posy].mob = mob;
		}
		worldGrid[boss.posx, boss.posy].boss = boss;
		return "3,1";
		}
		public String Level3() {
			triggerNo = 0;
			worldGrid = new Tile[22, 10];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (r == 0 && (c >= 0 && c <= 21)) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && (c >= 0 && c <= 21)) {
						if (c == 19) {
							mobs.Add (new Mob (c, r));
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 3) || (c >=6 && c <= 8) || (c >= 11 && c <= 13) || (c >= 16 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 2 && (c >= 0 && c <= 21)) {
						if (c == 7 || c == 11 || c == 16) {
							mobs.Add (new Mob (c, r));
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 3) || (c >=6 && c <= 8) || (c >= 11 && c <= 13) || (c >= 16 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 3 && (c >= 0 && c <= 21)) {
						if (c == 4 || c == 13 || c == 18) {
							mobs.Add (new Mob (c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 0 || (c >= 9 && c <= 10) || c == 21) {
							worldGrid [c, r].wall = true;
						} else if (c == 5 || c == 15) {
							worldGrid [c, r].trigger = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 4 && (c >= 0 && c <= 21)) {
						if (c == 10) {
							worldGrid [c, r].trigger = true;
						} else if ((c >= 1 && c <= 3) || (c >= 6 && c <= 13) || (c >= 16 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if ((r == 5 || r == 6) && (c >= 0 && c <= 21)) {
						if (r ==5 && (c == 7 || c == 12 || c == 17)) {
							mobs.Add (new Mob (c, r));
							worldGrid [c, r].floor = true;
						} else if (r == 6 && c == 20) {
							boss = new Boss(c, r, "Lock1");
				   			worldGrid[c, r].floor = true;
						} else if ((c >= 1 && c <= 3) || (c >=6 && c <= 8) || (c >= 11 && c <= 13) || (c >= 16 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 7 && (c >= 0 && c <= 21)) {
						if (c == 3) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 8 && (c >= 2 && c <= 8)) {
						if (c == 2 || c == 8) {
							worldGrid [c, r].wall = true;
						} else if (c == 3) {
							worldGrid [c, r].trigger = true;
						} else if (c == 7) {
							worldGrid [c, r].end = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 9 && (c >= 2 && c <= 8)) {
						worldGrid [c, r].wall = true;
					}
//Renderable Areas
					if ((r >= 0 && r <= 7) && (c >= 0 && c <= 5)) {
						if (((r >= 0 && r <= 1) || (r >= 5 && r <= 7)) && (c >= 0 && c <= 4)) {
							worldGrid [c, r].renderable = 1;
						}  else if (r >= 2 && r <= 4) {
							worldGrid [c, r].renderable = 1;
						}
					}
					if ((r >= 0 && r <= 7) && (c >= 5 && c <= 10)) {
						if ((r == 0 || r == 1 || r == 6 || r == 7) && (c >= 5 && c <= 9)) {
							worldGrid [c, r].renderable = 2;
						} else if (r == 2 && (c >= 6 && c <= 9)) {
							worldGrid [c, r].renderable = 2;
						} else if ((r == 3 || r == 4) && (c >= 6 && c <= 10)) {
							worldGrid [c, r].renderable = 2;
						} else if (r == 5 &7 (c >= 5 && c <= 10)) {
							worldGrid [c, r].renderable = 2;
						}
					}
					if ((r >= 0 && r <= 7) && (c >= 10 && c <= 15)) {
						if ((r == 0 || r == 1 || r == 6 || r == 7) && (c >= 10 && c <= 14)) {
							worldGrid [c, r].renderable = 3;
						} else if (r == 2 && (c >= 10 && c <= 15)) {
							worldGrid [c, r].renderable = 3;
						} else if ((r == 3 || r == 4) && (c >= 11 && c <= 15)) {
							worldGrid [c, r].renderable = 3;
						} else if (r == 5 && (c >= 11 && c <= 14)) {
							worldGrid [c, r].renderable = 3;
						}
					}
					if ((r >= 0 && r <= 7) && (c >= 15 && c <= 21)) {
						if (r == 0 || r == 1 || (r >= 5 && r <= 7)) {
							worldGrid [c, r].renderable = 4;
						} else if ((r >= 2 && r <= 4) && (c >= 16 && c <= 21)) {
							worldGrid [c, r].renderable = 4;
						}
					}
					if (r == 8 || r == 9) {
						worldGrid [c, r].renderable = 5;
					}
				}
					
			}
			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
		        worldGrid[boss.posx, boss.posy].boss = boss;
			return "1,4";
		}
		public String Level4() {
			triggerNo = 0;
			worldGrid = new Tile[19, 20];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (r == 0 && (c >= 3 && c <= 5)) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && (c >= 3 && c <= 9)) {
						if (c == 4) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if ((r == 2 || r == 3) && (c >= 3 && c <= 9)) {
						if (r == 2 && c == 7) {
							worldGrid [c, r].end = true;
						} else if (c == 4 || (c >= 6 && c <= 8)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 4 && (c >= 0 && c <= 9)) {
						if (c == 7) {
							worldGrid [c, r].trigger = true;
						} else if (c == 4 || (c >= 6 && c <= 8)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 5 && (c >= 0 && c <= 18)) {
						if (c == 4) {
							worldGrid [c, r].trigger = true;
						} else if (c == 7) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if (c >= 1 && c <= 4) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 6 && (c >= 0 && c <= 18)) {
						if (c == 11 || c == 16) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true; 
						} else if (c == 17) {
							worldGrid [c, r].trigger = true;
						} else if (c == 0 || c == 5 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 7 && (c >= 0 && c <= 18)) {
						if ((c >= 1 && c <= 4) || c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 8 && (c >= 0 && c <= 18)) {
						if (c == 5) {
							worldGrid [c, r].trigger = true;
						} else if (c == 10) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true; 
						} else if (c == 0 || c == 14 || c == 16 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 9 && (c >= 0 && c <= 18)) {
						if (c == 13) {
							worldGrid [c, r].trigger = true;
						} else if (c == 15 || c == 17) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 15 || c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 10 && (c >= 0 && c <= 18)) {
						if (c == 4) {
							worldGrid [c, r].trigger = true;
						} else if (c == 0 || c == 14 || c == 16 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}	
					if (r == 11 && (c >= 0 && c <= 18)) {
						if (c == 1) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 15) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else if ((c >= 2 && c <= 4) || c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 12 && (c >= 0 && c <= 18)) {
						if (c == 17) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 13) {
							boss = new Boss(c, r, "Lock2");
				    			worldGrid[c, r].floor = true;
						} else if (c == 0 || c == 5 || c == 12 || c == 14 || c == 16 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 13 && (c >= 0 && c <= 18)) {
						if (c == 3 || c == 15) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 11) {
							worldGrid [c, r].trigger = true;
						} else if ((c >= 1 && c <= 4) || c == 6 || c == 11 || c == 13 || c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 14 && (c >= 0 && c <= 18)) {
						if (c == 0 || c == 5 || c == 10 || c == 12 || c == 14 || c == 16 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 15 && (c >= 0 && c <= 18)) {
						if (c == 17) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 15) {
							worldGrid [c, r].trigger = true;
						} else if ((c >= 1 && c <= 4) || c == 9 || c == 13 || c == 15 || c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 16 && (c >= 0 && c <= 18)) {
						if (c == 2 || c == 9 || c == 11) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 5) {
							worldGrid [c, r].trigger = true;
						} else if (c == 0 || c == 10 || c == 16 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 17 && (c >= 0 && c <= 18)) {
						if (c == 13) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 17) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && (c >= 12 && c <= 18)) {
						if (c == 13) {
							worldGrid [c, r].trigger = true;
						} else if (c == 15) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 12 || c == 18) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 19 && (c >= 12 && c <= 18)) {
						worldGrid [c, r].wall = true;
					}
// Renderable Areas
					if ((r >= 4 && r <= 9) && (c >= 0 && c <= 5)) {
						if (r == 4 && (c >= 0 && c <= 2)) {
							worldGrid [c, r].renderable = 1;
						} else if (r == 5 && (c >= 0 && c <= 3) {
							worldGrid [c, r].renderable = 1;
						} else if (r >= 6 && r <= 9) {
							worldGrid [c, r].renderable = 1;
						}
					}
					if ((r >= 7 && r <= 9) && (c >= 6 && c <= 14)) {
						worldGrid [c, r].renderable = 2;
					} 
					if ((r == 10 || r == 11) && (c >= 4 && c <= 14)) {
						if (r == 10) {
							worldGrid [c, r].renderable = 3;
						} else if (r == 11 && (c >= 5 && c <= 14)) {
							worldGrid [c, r].renderable = 3;
						}
					}
					if ((r >= 10 && r <= 17) && (c >= 0 && c <= 5)) {
						if (r == 10 && (c >= 0 && c <= 3)) {
							worldGrid [c, r].renderable = 4;
						} else if (r == 11 && (c >= 0 && c <= 4)) {
							worldGrid [c, r].renderable = 4;
						} else if (r >= 12 && r <= 17) {
							worldGrid [c, r].renderable = 4;
						}
					}
					if ((r >= 12 && r <= 17) && (c >= 6 && c <= 12)) {
						if (r == 12 || r == 13) {
							worldGrid [c, r].renderable = 5;
						} else if ((r >= 14 && r <= 17) && (c >= 6 && c <= 10)) {
							worldGrid [c, r].renderable = 5;
						}
					}
					if ((r >= 12 && r <= 19) && (c >= 11 && c <= 16)) {
						if ((r == 12 || r == 13) && (c == 13 || c == 14)) {
							worldGrid [c, r].renderable = 6;
						} else if (r == 14 && (c >= 11 && c <= 14)) {
							worldGrid [c, r].renderable = 6;
						} else if (r >= 15 && r <= 17) {
							worldGrid [c, r].renderable = 6;
						} else if ((r == 18 || r == 19) && (c == 12 || c == 13)) {
							worldGrid [c, r].renderable = 6;
						}
					}
					if ((r >= 7 && r <= 14) && (c == 15 || c == 16)) {
						worldGrid [c, r].renderable = 7;
					}
					if ((r >= 5 && r <= 19) && (c >= 14 && c <= 18)) {
						if ((r >= 5 && r <= 17) && (c == 17 || c == 18)) {
							worldGrid [c, r].renderable = 8;
						} else if (r == 18 || r == 19) {
							worldGrid [c, r].renderable = 8;
						}
					}
					if ((r >= 4 && r <= 6) && (c >= 6 && c <= 16)) {
						if (r == 4 && c == 7) {
							worldGrid [c, r].renderable = 9;
						} else if (r == 5 || r == 60 {
							worldGrid [c, r].renderable = 9;
						}
					}
					if ((r >= 1 && r <= 4) && (c >= 6 && c <= 9)) {
						if (r >= 1 && r <= 3) {
							worldGrid [c, r].renderable = 10;
						} else if (r == 4  && (c == 6 || c == 8 || c == 9)) {
							worldGrid [c, r].renderable = 10;
						}
					}  	
				}
			}

			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
                        worldGrid[boss.posx, boss.posy].boss = boss;
			return "4,1";
		}
		public String Level5() {
			triggerNo = 0;
			worldGrid = new Tile[22, 21];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (r == 0 && (c >= 1 && c <= 11)) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && (c >= 1 && c <= 11)) {
						if (c == 2) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 1 || c == 11) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 2 && (c >= 1 && c <= 11)) {
						if (c == 5) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 5 || c == 6 || c == 10) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 3 && (c >= 1 && c <= 17)) {
						if (c == 2) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 10) {
							worldGrid [c, r].trigger = true;
						} else if ((c >= 3 && c <= 6) || c == 8) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 4 && (c >= 1 && c <= 17)) {
						if ((c >= 2 && c <= 6) || (c >= 8 && c <= 16)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 5 && (c >= 1 && c <= 17)) {
						if (c == 5) {
							worldGrid [c, r].trigger = true;
						} else if (c == 12) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 5 || (c >= 8 && c <= 16)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 6 && (c >= 4 && c <= 17)) {
						if (c == 8 || c == 16) {
							mobs.Add(new Mob(c, r));
							worldGrid [c, r].floor = true;
						} else if (c == 4 || c == 6 || c == 17) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 7 && (c >= 4 && c <= 21)) {
						if (c == 5 || (c >= 7 && c <= 16)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 8 && (c >= 0 && c <= 21)) {
						if (c == 5) {
							worldGrid [c, r].trigger = true;
						} else if (c == 12) {
							boss = new Boss(c, r, "Lock3");
				    			worldGrid[c, r].floor = true;
						} else if (c == 20) {
							worldGrid [c, r].end = true;
						} else if (c == 5 || (c >= 9 && c <= 16) || (c >= 18 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
// YOURE RIGHT HERE STEVEN
					if ((r == 9 || r == 10) && (c >= 0 && c <= 21)) {
						if (c == 0 || c == 8 || c == 17 || c == 21) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 11 && (c >= 0 && c <= 21)) {
						if ((c >= 1 && c <= 7) || (c >= 18 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 12 && (c >= 0 && c <= 21)) {
						if (c == 11) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 14) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 17) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c == 21) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 13 && (c >= 0 && c <= 21 )) {
						if ((c >= 1 && c <= 7) || (c >= 18 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 14 && (c >= 0 && c <= 21)) {
						if (c == 15) {
							worldGrid [c, r].item = new Key ("Key 2", "Lock2");
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 7) || c == 16) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 15 && (c >= 0 && c <= 21)) {
						if ((c >= 1 && c <= 7) || (c >= 11 && c <= 13) || (c >= 15 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 16 && (c >= 0 && c <= 21)) {
						if ((c >= 1 && c <= 11) || c == 13 || c == 17 || (c >= 19 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 17 && (c >= 0 && c <= 21)) {
						if (c == 2 || c == 5 || (c >= 13 && c <= 17) || (c >= 19 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && (c >= 1 && c <= 21)) {
						if (c == 2 || c == 5 || (c >= 7 && c <= 11) || c == 13 || c == 15 || (c >= 19 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 19 && (c >= 1 && c <= 21)) {
						if (c == 2 || (c >= 5 && c <= 7) || (c >= 11 && c <= 13) || (c >= 15 && c <= 20)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 20 && (c >= 1 && c <= 21)) {
						worldGrid [c, r].wall = true;
					}
				}
			}

			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
                        worldGrid[boss.posx, boss.posy].boss = boss;
			return "2,19";
		}
		public String Level6() {
			triggerNo = 0;
			worldGrid = new Tile[20, 25];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (r == 0 && ((c >= 0 && c <= 5) || (c >= 12 && c <= 19))) {
						worldGrid [c, r].wall = true;
					}
					if ((r >= 1 && r <= 3) && ((c >= 0 && c <= 5) || (c >= 12 && c <= 19))) {
						if ((c >= 1 && c <= 4) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 4 && ((c >= 0 && c <= 5) || (c >= 7 && c <= 19))) {
						if (c == 3 || c == 13) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 5 && ((c >= 2 && c <= 4) || (c >= 7 && c <= 19))) {
						if (c == 3 || (c >= 8 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 6 && ((c >= 0 && c <= 4) || (c >= 7 && c <= 19))) {
						if (c == 3) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 13) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else if ((c >= 8 && c <= 10) || (c >= 16 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 7 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 3) || (c >= 8 && c <= 10) || (c >= 12 && c <= 14) || (c >= 16 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 8 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 10) || (c >= 12 && c <= 14) || c == 18) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					} 
					if (r == 9 && (c >= 0 && c <= 19)) {
						if (c == 13) {
							worldGrid [c, r].end = true;
						} else if (c == 16) {
							worldGrid [c, r].item = new Key ("Key 2", "Lock2");
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 3) || (c >= 12 && c <= 14) || (c >= 16 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 10 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 10) || (c >= 16 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 11 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 2) || c == 8 || c == 10 || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 12 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 2) || (c >= 4 && c <= 6) || c == 8 || c == 10 || c == 13) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 13 && (c >= 0 && c <= 19)) {
						if (c == 12) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c == 3 || c == 7 || c == 14 || c == 19) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 14 && (c >= 0 && c <= 19)) {
						if (c == 3) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 6) || (c >= 15 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 15 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 2) || (c >= 8 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 16 && (c >= 0 && c <= 19)) {
						if ((c >= 1 && c <= 5) || (c == 8) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 17 && (c >= 0 && c <= 19)) {
						if ((c >= 1 &&  c <= 5) || (c >= 7 && c <= 11) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && (c >= 0 && c <= 19)) {
						if (c == 5 || (c >= 7 && c <= 11) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 19 && (c >= 4 && c <= 19)) {
						if (c == 5 || (c >= 7 && c <= 11) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 20 && (c >= 2 && c <= 19)) {
						if (c == 5 || (c >= 7 && c <= 11) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 21 && (c >= 2 && c <= 19)) {
						if ((c >= 3 && c <= 5) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 22 && (c >= 2 && c <= 19)) {
						if (c >= 3 && c <= 18) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 23 && (c >= 2 && c <= 19)) {
						if ((c >= 3 && c <= 6) || (c >= 13 && c <= 18)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 24 && ((c >= 2 && c <= 7) || (c >= 12 && c <= 19))) {
						worldGrid [c, r].wall = true;
					}						
						
				}
			}

			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
                        worldGrid[boss.posx, boss.posy].boss = boss;
			return "18,2";
		}
		public String Level7() {
			triggerNo = 0;
			worldGrid = new Tile[14, 23];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					if (r == 0 && (c >= 0 && c <= 13)) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && (c >= 0 && c <= 13)) {
						if (c == 4) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else if (c == 0 || c ==13) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 2 && (c >= 0 && c <= 13)) {
						if (c == 6 || c == 12) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if ((r == 3 || r == 4) && (c >= 0 && c <= 13)) {
						if (c == 0 || c == 11 || c == 13) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 5 && (c >= 0 && c <= 13)) {
						if ((c >= 1 && c <= 8) || c == 12) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if ((r >= 6 && r <= 8) && (c >= 0 && c <= 13)) {
						if (c == 0 || c == 9 || c == 13) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 9 && (c >= 0&& c <= 13)) {
						if (c == 4 || c == 8 || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if ((r >= 10 && r <= 12) && (c >= 0 && c <= 12)) {
						if ((c >= 1 && c <= 4) || (c >= 6 && c <= 9) || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 13 && (c >= 0 && c <= 12)) {
						if (c == 1 || c == 2 || c == 6 || c == 9 || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 14 && (c >= 0 && c <= 12)) {
						if (c == 2 || (c >= 4 && c <= 6) || c == 8 || c == 9 || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 15 && (c >= 0 && c <= 12)) {
						if ((c >= 1 && c <= 2) || (c >= 4 && c <= 6) || (c >= 8 && c <= 9) || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 16 && (c >= 0 && c <= 12)) {
						if ((c >= 1 && c <= 6) || (c >= 8 && c <= 9) || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 17 && (c >= 0 && c <= 12)) {
						if (c == 2 || c == 6 || (c >= 8 && c <= 11)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && (c >= 0 && c <= 12)) {
						if ((c >= 1 && c <= 2) || (c >= 4 && c <= 6) || (c >= 8 && c <= 11)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 19 && (c >= 0 && c <= 12)) {
						if (c == 4) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else if ((c >= 1 && c <= 2) || (c >= 4 && c <= 11)) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 20 && (c >= 0 && c <= 12)) {
						if (c == 1 || c == 2) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 21 && (c >= 0 && c <= 12)) {
						if (c == 4) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else if (c == 11) {
							worldGrid [c, r].end = true;
						} else if (c >= 2 && c <= 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 22 && (c >= 1 && c <= 12)) {
						worldGrid [c, r].wall = true;
					}

				}
			}
			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
                        worldGrid[boss.posx, boss.posy].boss = boss;
			return "8,11";
		}					
		public String Level8() {
			triggerNo = 0;
			worldGrid = new Tile[13, 21];

			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {
					worldGrid [c, r] = new Tile ();
				}
			}
			for (int c = 0; c < worldGrid.GetLength (0); c++) {
				for (int r = 0; r < worldGrid.GetLength (1); r++) {

					if (r == 0 && (c >= 2 && c <= 10)) {
						worldGrid [c, r].wall = true;
					}
					if (r == 1 && (c >= 2 && c <= 12)) {
						if (c == 2 || c == 4 || c == 10 || c == 11 || c == 12) {
							worldGrid [c, r].wall = true;
						} else if (c == 9) {
							worldGrid [c, r].end = true;
						} else if (c == 7) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock4");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 2 && (c >= 2 && c <= 12)) {
						if (c == 3 || c == 5 || c == 11) {
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 3 && (c >= 2 && c <= 12)) {
						if (c == 2 || c == 4 || c == 12) {
							worldGrid [c, r].wall = true;
						} else if (c == 3) {
							worldGrid [c, r].item = new Key ("Key 1", "Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 4 && (c >= 0 && c <= 12)) {
						if (c == 9) {
							worldGrid [c, r].floor = true;
						} else if (c == 3) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock1");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 5 && (c >= 0 && c <= 10)) {
						if (c == 0 || c == 8 || c == 10) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 6 && (c >= 0 && c <= 10)) {
						if (c == 0 || c == 8 || c == 10) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 7 && (c >= 0 && c <= 10)) {
						if ((c >= 0 && c <= 2) || c == 4 || c == 10) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 8 && (c >= 0 && c <= 10)) {
						if (c == 0 || c == 4 || (c >= 6 && c <= 10)) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 9 && (c >=0 && c <= 10)) {
						if (c == 0 || c == 2 || c == 4 || (c >= 8 && c <= 10)) {
							worldGrid [c, r].wall = true;
						} else if (c == 6) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock2");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 10 && (c >= 0 && c <= 10)) {
						if (c == 0 || c == 2 || c == 4 || c == 6 || c == 10) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 11 && (c >= 0 && c <= 12)) {
						if (c == 0 || c == 2 || (c >= 6 && c <= 8) || (c >= 10 && c <= 12)) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 12 && (c >= 0 && c <= 12)) {
						if (c == 0 || c == 2 || c == 3 || (c >= 6 && c <= 8) || c == 12) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 13 && (c >= 0 && c <= 12)) {
						if (c == 0 || (c >= 3 && c <= 8) || c == 12) {
							worldGrid [c, r].wall = true;
						} else if (c == 2) {
							worldGrid [c, r].item = new Key ("Key 2", "Lock2");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 14 && ((c >= 0 && c <= 3) || (c >= 6 && c <= 12))) {
						if ((c >= 0 && c <= 3) || (c >= 6 && c <= 8) || c== 12) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 15 && (c >= 6 && c <= 12)) {
						if (c == 6 || c == 8 || c == 12) {
							worldGrid [c, r].wall = true;
						} else if (c == 7) {
							worldGrid [c, r].item = new Key ("Key 3", "Lock3");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 16 && (c >= 6 && c <= 12)) {
						if (c == 6 || c == 12) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 17 && (c >= 6 && c <= 12)) {
						if (c == 11) {
							worldGrid [c, r].door = true;
							worldGrid [c, r].SetKeypass ("Lock3");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].wall = true;
						}
					}
					if (r == 18 && (c >= 8 && c <= 12)) {
						if (c == 8 || c == 12) {
							worldGrid [c, r].wall = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 19 && (c >= 8 && c <= 12)) {
						if (c == 8 || c == 12) {
							worldGrid [c, r].wall = true;
						} else if (c == 9) {
							worldGrid [c, r].item = new Key ("Key 4", "Lock4");
							worldGrid [c, r].floor = true;
						} else {
							worldGrid [c, r].floor = true;
						}
					}
					if (r == 20 && (c >= 8 && c <= 12)) {
						worldGrid [c, r].wall = true;
					}
				}
			}
			foreach (Mob mob in mobs) {
				worldGrid[mob.posx, mob.posy].mob = mob;
			}
			worldGrid[boss.posx, boss.posy].boss = boss;
			return "3,1";



		}				
	}
}
