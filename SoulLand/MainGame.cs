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
		private Camera2D cam;
		enum gameState
		{
			Intro,
			MainMenu,
			Level
		}

		//Logger Singleton
		Logger GameLog;

		public MainGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			//Create Logger
			GameLog = new Logger();

			gameState = gameState.Intro;

		

		}

		protected override void Initialize()
		{
			var viewPortAdapter = new BoxingViewportAdapter (Window, graphics, 800, 480);
			cam = new Camera2D (viewPortAdapter);
			base.Initialize();
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

			if (Keyboard.GetState ().IsKeyDown (Keys.A)) {
				cam.Move (new Vector2 (-5, 0));
			}
			if (Keyboard.GetState ().IsKeyDown (Keys.D)) {
				cam.Move (new Vector2 (5, 0));
			}
			if (Keyboard.GetState ().IsKeyDown (Keys.W)) {
				cam.Move (new Vector2 (0, -5));
			}
			if (Keyboard.GetState ().IsKeyDown (Keys.S)) {
				cam.Move (new Vector2 (0, 5));
			}



			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Beige);

			var transformMatrix = cam.GetViewMatrix ();
			spriteBatch.Begin (transformMatrix: transformMatrix);
			MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (400, 240, 60, 60), Color.Black,10);
			spriteBatch.End ();

			base.Draw(gameTime);
		}

		public Logger GetLog()
		{
			return GameLog;
		}
	}
}

