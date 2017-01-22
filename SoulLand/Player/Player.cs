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

			posx = 20;
			posy = 20;
		}
	}
}

