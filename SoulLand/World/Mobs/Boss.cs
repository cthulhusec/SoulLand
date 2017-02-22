using System;

namespace SoulLand
{/* 
     TO DO LIST:
        render help screen on consuming charm
        give charms effects
     */
	[Serializable]
	public class Boss
	{
		public int posx = 0;
        public int posy = 0;
        public int health = 3;
        public string keyString = "";
        public Boss (int tempX, int tempY, string tempString)
		{
			posx = tempX;
			posy = tempY;
            keyString = tempString;
		}
		public Boolean Within(Player player) {
			if (player.posx - posx < 4 && player.posx - posx > - 4 && player.posy - posy < 4 && player.posy - posy > -4) {
				return true;
			}
			return false;
		}
		public World Move(World world, Player player) {
			if (Within (player) && player.mobWaitAttack == 0) {
                if (((posx > player.posx - 2 && posy == player.posy) && (posx < player.posx + 2 && posy == player.posy)) || ((posx == player.posx && posy > player.posy - 2) && (posx == player.posx && posy < player.posy + 2)))
                {
                    if (health <= 0)
                    {
                        world.worldGrid[posx, posy].boss = null;
                        world.boss = null;
                        world.worldGrid[posx, posy].item = new Key("Boss Key", "Lock3");
                    }
                    else
                    {
                        health -= 1;
                        player.health -= 1;
                    }
                    return world;
                }
                if (posy > player.posy && Within (player)) {
					if (world.worldGrid [posx, posy - 1].wall || world.worldGrid [posx, posy - 1].door || world.worldGrid [posx, posy - 1].mob != null || world.worldGrid[player.posx, player.posy + 1].boss != null) {
					} else {
						world.worldGrid [posx, posy].boss = null;
						world.worldGrid [posx, posy - 1].boss = this;
						posy -= 1;
					}
				} else if (posy < player.posy && Within (player)) {
					if (world.worldGrid [posx, posy + 1].wall || world.worldGrid [posx, posy + 1].door || world.worldGrid [posx, posy + 1].mob != null || world.worldGrid[player.posx, player.posy - 1].boss != null) {
					} else {
						world.worldGrid [posx, posy].boss = null;
						world.worldGrid [posx, posy + 1].boss = this;
						posy += 1;
					}
				} else if (posx > player.posx && Within (player)) {
					if (world.worldGrid [posx - 1, posy].wall || world.worldGrid [posx - 1, posy].door || world.worldGrid [posx - 1, posy].mob != null || world.worldGrid[player.posx + 1, player.posy].boss != null) {
					} else {
						world.worldGrid [posx, posy].boss = null;
						world.worldGrid [posx - 1, posy].boss = this;
						posx -= 1;
					}
				} else if (posx < player.posx && Within (player)) {
					if (world.worldGrid [posx + 1, posy].wall || world.worldGrid [posx + 1, posy].door || world.worldGrid [posx + 1, posy].mob != null || world.worldGrid[player.posx - 1, player.posy].boss != null) {
					} else {
						world.worldGrid [posx, posy].boss = null;
						world.worldGrid [posx + 1, posy].boss = this;
						posx += 1;
					}
				}
            }
            return world;
        }
	}
}

