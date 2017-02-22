using System;
using System.Collections;

namespace SoulLand
{
	[Serializable]
	public class Mob
	{
		public int health;
		public int posx = 0;
		public int posy = 0;
		public Mob (int tempX, int tempY)
		{
			posx = tempX;
			posy = tempY;
		}
		public Boolean Within(Player player) {
			if (player.posx - posx < 4 && player.posx - posx > - 4 && player.posy - posy < 4 && player.posy - posy > -4) {
				return true;
			}
			return false;
		}
		public World MobMove(World world, Player player, Mob a) {
			if (world.worldGrid [a.posx, a.posy].mob != null) {
				if (a.posx > player.posx && a.Within (player)) {
					if (world.worldGrid [a.posx - 1, a.posy].wall || world.worldGrid [a.posx - 1, a.posy].door || world.worldGrid[a.posx - 1, a.posy].mob != null || (player.mobWaitAttack > 0 && world.worldGrid[player.posx + 1, player.posy].mob != null)) {
						} else {
						world.worldGrid [a.posx, a.posy].mob = null;
						world.worldGrid [a.posx - 1, a.posy].mob = a;
						a.posx -= 1;
					}
				} else if (a.posx < player.posx && a.Within (player)) {
					if (world.worldGrid [a.posx + 1, a.posy].wall || world.worldGrid [a.posx + 1, a.posy].door || world.worldGrid [a.posx + 1, a.posy].mob != null || (player.mobWaitAttack > 0 && world.worldGrid[player.posx - 1, player.posy].mob != null)) {
						} else {
						world.worldGrid [a.posx, a.posy].mob = null;
						world.worldGrid [a.posx + 1, a.posy].mob = a;
						a.posx += 1;
					}
				} else if (a.posy > player.posy && a.Within (player)) {
					if (world.worldGrid [a.posx, a.posy - 1].wall || world.worldGrid [a.posx, a.posy - 1].door || world.worldGrid [a.posx, a.posy - 1].mob != null || (player.mobWaitAttack > 0 && world.worldGrid[player.posx, player.posy + 1].mob != null)) {
						} else {
						world.worldGrid [a.posx, a.posy].mob = null;
						world.worldGrid [a.posx, a.posy - 1].mob = a;
						a.posy -= 1;
					}
				} else if (a.posy < player.posy && a.Within (player)) {
					if (world.worldGrid [a.posx, a.posy + 1].wall || world.worldGrid [a.posx, a.posy + 1].door || world.worldGrid [a.posx, a.posy + 1].mob != null || (player.mobWaitAttack > 0 && world.worldGrid[player.posx, player.posy - 1].mob != null)) {
						} else {
						world.worldGrid [a.posx, a.posy].mob = null;
						world.worldGrid [a.posx, a.posy + 1].mob = a;
						a.posy += 1;
					}
				}
				if (player.mobWaitAttack == 0 && ((a.posx >= player.posx - 2 && a.posy == player.posy) && (a.posx <= player.posx + 2 && a.posy == player.posy)) || ((a.posx == player.posx && a.posy >= player.posy - 2) && (a.posx == player.posx && a.posy <= player.posy - 2))) {
					world.worldGrid [a.posx, a.posy].mob = null;
					world.mobs.Remove (a);
					player.health -= 1;
				} else
                {
                    player.mobWaitAttack -= 1;
                    if (player.mobWaitAttack < 0)
                    {
                        player.mobWaitAttack = 0;
                    }
                }
            }
			return world;
		}
	}
}

