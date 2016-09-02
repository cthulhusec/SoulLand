using System;

namespace SoulLand
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			using (MainGame game = new MainGame())
			{
				game.Run();
			}
		}
	}
}
