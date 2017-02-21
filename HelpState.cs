using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.BitmapFonts;

namespace SoulLand
{
	public class HelpState : State
	{
		BitmapFont mainTextFont;

		private int switchCase;

		KeyboardState oldState;

		public HelpState (MainGame g) : base(g)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState();

			if (Keyboard.GetState().IsKeyDown(Keys.Enter) && oldState.IsKeyDown(Keys.Enter) != true)
			{
				switchCase++;
			}

			oldState = newState;
		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin(transformMatrix: game.globalTransformation);
			switch (switchCase)
			{
			case 0:
				spriteBatch.DrawString(mainTextFont, "PUT TEXT HERE", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("PUT TEXT HERE").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
				break;
			default:
				game.ChangeState(MainGame.GameState.MainMenu);
				break;
			}
			spriteBatch.End();
		}

		protected override void LoadContent()
		{
			cm.RootDirectory = "Content/Assets";
			mainTextFont = cm.Load<BitmapFont>("Fonts/PressPlayFont");
		}
	}
}

