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
				spriteBatch.DrawString(mainTextFont, "Move Using W A S D", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Move Using W A S D").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 1:
				spriteBatch.DrawString(mainTextFont, "Pick Up Items With F", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Pick Up Items With F").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 2:
				spriteBatch.DrawString(mainTextFont, "Use Q to Zoom In and E to Zoom Out", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Use Q To Zoom In and E to Zoom Out").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 3:
				spriteBatch.DrawString(mainTextFont, "Open Inventory With I", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Open Inventory With I").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 4:
				spriteBatch.DrawString(mainTextFont, "Attack Mobs with the Arrow Keys", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Attack Mobs with the Arrow Keys").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 5:
				spriteBatch.DrawString(mainTextFont, "Move Onto Doors to Open Them", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Move Onto Doors to Open Them").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 6:
				spriteBatch.DrawString(mainTextFont, "Kill the Boss on Each Level to Gain the Key that Opens the Final Door", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Kill the Boss on Each Level to Gain the Key that Opens the Final Door").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
			case 7:
				spriteBatch.DrawString(mainTextFont, "Attempt to Survive All Levels to Win!", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Attempt to Survive All Levels to Win!").X / 2), game.baseScreenSize.Y / 2), Color.AntiqueWhite);
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

