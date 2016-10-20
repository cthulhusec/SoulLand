using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ViewportAdapters;

namespace SoulLand
{
	public class MainMenuState : State
	{
		public enum MenuState
		{
			main,
			resume,
			newGame,
			options,
			credits
		}


		private MenuState mState;
		bool resumeAble = false;
		Vector2 selectionPos;
		KeyboardState oldState;
		int selection = 0;

		public MainMenuState (MainGame g) : base(g)
		{
			game = g;
			graphics = game.graphics;
			resumeAble = game.gameData != null;
			mState = MenuState.main;
			oldState = Keyboard.GetState ();
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();
			if (newState.IsKeyDown(Keys.Down) && oldState.IsKeyDown(Keys.Down) != true) {
				selection += 1;
				selection = MathHelper.Clamp (selection, 0, 3);
			}
			else if (Keyboard.GetState ().IsKeyDown (Keys.Up) && oldState.IsKeyDown(Keys.Up) != true) {
				selection -= 1;
				selection = MathHelper.Clamp (selection, 0, 3);
			}

			if (newState.IsKeyDown (Keys.Enter) && oldState.IsKeyDown (Keys.Enter) != true) {
				switch (selection) {
				case 0:
					game.ChangeState (MainGame.GameState.Level);
					break;
				case 1:
					break;
				case 3:
					game.Exit ();
					break;
				}
			}

			oldState = newState;
		}

		public override void Draw(GameTime gameTime)
		{
			//spriteBatch.Begin (transformMatrix: ((MainGame)game).viewportAdapter.GetScaleMatrix());
			spriteBatch.Begin(transformMatrix: game.globalTransformation);
			//draw title
			MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-450,game.baseScreenSize.Y/20,800,150),Color.BlueViolet,10);

			selectionPos = new Vector2 (game.baseScreenSize.X / 2-225, game.baseScreenSize.Y/ 20 + 275);

			switch (mState) {
			case MenuState.main:
				MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-200,game.baseScreenSize.Y/20 + 300,300,100),Color.BlueViolet,10);
				MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-200,game.baseScreenSize.Y/20 + 450,300,100),Color.BlueViolet,10);
				MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-200,game.baseScreenSize.Y/20 + 600,300,100),Color.BlueViolet,10);
				MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-200,game.baseScreenSize.Y/20 + 750,300,100),Color.BlueViolet,10);
				MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(selectionPos.X,selectionPos.Y + (150*selection),350,150),Color.HotPink,15);

				break;

			case MenuState.newGame:
				break;

			case MenuState.resume:
				break;

			case MenuState.options:
				break;

			case MenuState.credits:
				break;
			}
				

			spriteBatch.End ();

		}

		protected override void LoadContent()
		{
			
		}
	}
}

