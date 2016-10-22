using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.BitmapFonts;

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

		BitmapFont mainTextFont;

		public MainMenuState (MainGame g) : base(g)
		{
			game = g;
			graphics = game.graphics;
			resumeAble = (game.gameData != null);
			mState = MenuState.main;
			oldState = Keyboard.GetState ();
			if (!resumeAble)
			{
				selection = 1;
			}
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();
			if (newState.IsKeyDown(Keys.Down) && oldState.IsKeyDown(Keys.Down) != true) {
				selection += 1;
				if (!resumeAble)
				{
					selection = MathHelper.Clamp(selection, 1, 3);
				}
				else
				{
					selection = MathHelper.Clamp(selection, 0, 3);
				}
			}
			else if (Keyboard.GetState ().IsKeyDown (Keys.Up) && oldState.IsKeyDown(Keys.Up) != true) {
				selection -= 1;
				if (!resumeAble)
				{
					selection = MathHelper.Clamp(selection, 1, 3);
				}
				else
				{
					selection = MathHelper.Clamp(selection, 0, 3);
				}
			}

			if (newState.IsKeyDown (Keys.Enter) && oldState.IsKeyDown (Keys.Enter) != true) {
				switch (selection) {
				case 0:
					game.ChangeState (MainGame.GameState.Level);
					break;
				case 1:
						if (game.gameData == null)
						{
							game.gameData = new GameData();
							SaveSystem.SaveGameData(game.gameData);
						}
						game.ChangeState(MainGame.GameState.Level);
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
			//MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-450,game.baseScreenSize.Y/20,800,150),Color.BlueViolet,10);
			spriteBatch.DrawString(mainTextFont, "Soul Land", new Vector2(game.baseScreenSize.X / 2-(mainTextFont.MeasureString("Soul Land") / 2).X, game.baseScreenSize.Y / 20), Color.Plum );


			selectionPos = new Vector2 (game.baseScreenSize.X / 2-175, game.baseScreenSize.Y/ 20 + 275);

			switch (mState) {
			case MenuState.main:
					if (!resumeAble)
					{
						spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.Gray);
					}
					else if (selection == 0 && resumeAble)
					{
						spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.CadetBlue);
					}
					else
					{
						spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.Black);
					}
					if (selection == 1)
					{
						spriteBatch.DrawString(mainTextFont, "New Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("New Game") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.CadetBlue);
					}
					else
					{
						spriteBatch.DrawString(mainTextFont, "New Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("New Game") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.Black);
					}
					if (selection == 2)
					{
						spriteBatch.DrawString(mainTextFont, "Options", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Options") / 2).X, game.baseScreenSize.Y / 20 + 600), Color.CadetBlue);

					}
					else
					{
						spriteBatch.DrawString(mainTextFont, "Options", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Options") / 2).X, game.baseScreenSize.Y / 20 + 600), Color.Black);
					}
					if (selection == 3)
					{
						spriteBatch.DrawString(mainTextFont, "Quit", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Quit") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.CadetBlue);
					}
					else
					{
						spriteBatch.DrawString(mainTextFont, "Quit", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Quit") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.Black);
					}
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
			cm.RootDirectory = "Content/Assets";
			mainTextFont = cm.Load<BitmapFont>("Fonts/PressPlayFont");
		}
	}
}

