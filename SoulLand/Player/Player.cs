using System;
using Microsoft.Xna.Framework;
namespace SoulLand
{
	[Serializable]
	public class Player
	{
		public int posx;
		public int posy;

		public int health;


		public Player()
		{
			health = 5;
			posx = 20;
			posy = 20;
		}

        public World Attack(World world, int direction)
        {
            if (direction == 1) // direction == 1 is stating the player attacks up
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (world.worldGrid[posx, posy - i].mob != null)
                    {
                        world.worldGrid[posx, posy - i].mob = null;
                    }
                    else if (world.worldGrid[posx, posy - i].boss != null)
                    {
                        world.boss.health -= 1;
                    }
                }
            }
            else if (direction == 2) // direction == 2 is stating the player attacks right
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (world.worldGrid[posx + i, posy].mob != null)
                    {
                        world.worldGrid[posx + i, posy].mob = null;
                    }
                    else if (world.worldGrid[posx + i, posy].boss != null)
                    {
                        world.boss.health-= 1;
                    }
                }
            }
            else if (direction == 3) // direction == 3 is stating the player attacks down
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (world.worldGrid[posx, posy + i].mob != null)
                    {
                        world.worldGrid[posx, posy + i].mob = null;
                    }
                    else if (world.worldGrid[posx, posy + i].boss != null)
                    {
                        world.worldGrid[posx, posy + i].boss.health -= 1;
                    }
                }
            }
            else if (direction == 4) // direction == 4 is stating the player attacks Left
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (world.worldGrid[posx - i, posy].mob != null)
                    {
                        world.worldGrid[posx - i, posy].mob = null;
                    }
                    else if (world.worldGrid[posx - i, posy].boss != null)
                    {
                        world.worldGrid[posx - i, posy].boss.health -= 1;
                    }
                }
            }
            return world;
        }
	}
}

