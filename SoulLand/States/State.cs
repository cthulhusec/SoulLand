using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace SoulLand
{
	public abstract class State
	{
		protected SpriteBatch spriteBatch;
		protected Game game;
		protected ContentManager cm;
		protected GraphicsDeviceManager graphics;


		protected State (Game g)
		{
			game = g;
			cm = new ContentManager(g.Services);
			graphics = ((MainGame)game).graphics;
			LoadContent();

			spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

		}

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);
		protected abstract void LoadContent();
		public void UnLoadContent()
		{
			cm.Unload ();
		}
	}
}

