using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace SoulLand
{
	public class LevelState : State
	{
		private Camera2D cam;

		public LevelState (Game g) : base(g)
		{

			var viewPortAdapter = new BoxingViewportAdapter(game.Window, graphics, 800, 480);
			cam = new Camera2D(viewPortAdapter);
		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				cam.Move(new Vector2(-5, 0));
			}
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				cam.Move(new Vector2(5, 0));
			}
			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				cam.Move(new Vector2(0, -5));
			}
			if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				cam.Move(new Vector2(0, 5));
			}

			if (Keyboard.GetState ().IsKeyDown (Keys.Enter)) {
				((MainGame)game).ChangeState (MainGame.GameState.Intro);
			}
					
		}

		public override void Draw(GameTime gameTime)
		{
			var transformMatrix = cam.GetViewMatrix();
			spriteBatch.Begin(transformMatrix: transformMatrix);
			MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch, new MonoGame.Extended.Shapes.RectangleF(400, 240, 60, 60), Color.Black, 10);
			spriteBatch.End();
		}

		protected override void LoadContent()
		{

		}
	}
}

