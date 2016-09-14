using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace SoulLand
{
	public class MainGame :Game
	{

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public enum GameState
		{
			Intro,
			MainMenu,
			Level
		}
		public GameState gs;

		public State state;

		//Logger Singleton
		Logger GameLog;

		public MainGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			//Create Logger
			GameLog = new Logger();
		

		}


		protected override void Initialize()
		{
			base.Initialize();

			state = new LevelState(this, graphics);
			gs = GameState.Level;

		}

		protected override void LoadContent()
		{
			base.LoadContent();

			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			switch (gs)
			{
				case GameState.Level:
					state.Update(gameTime);
					break;
			}

					


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Beige);

			switch (gs)
			{
				case GameState.Level:
					state.Draw(gameTime);
					break;
			}

			base.Draw(gameTime);
		}

		public Logger GetLog()
		{
			return GameLog;
		}
	}
}

