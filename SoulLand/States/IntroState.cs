using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.BitmapFonts;


namespace SoulLand
{
	public class IntroState : State
	{
        BitmapFont mainTextFont;

        private int switchCase;

        KeyboardState oldState;

        public IntroState (MainGame g) : base(g)
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
					spriteBatch.DrawString(mainTextFont, "Cognitive Thought Media", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Cognitive Thought Media").X / 2), game.baseScreenSize.Y / 2), Color.CadetBlue);
                    break;
                case 1:
					spriteBatch.DrawString(mainTextFont, "Thunder Punch Productions", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Thunder Punch Productions").X / 2), game.baseScreenSize.Y / 2), Color.CadetBlue);
					break;
                case 2:
                    game.ChangeState(MainGame.GameState.MainMenu);
                    break;
            }
			spriteBatch.DrawString(mainTextFont, "Press  ENTER  to continue", new Vector2(((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Press  ENTER  to continue").X / 2)+500), game.baseScreenSize.Y - 50), Color.Magenta);

            spriteBatch.End();
        }

        protected override void LoadContent()
		{
            cm.RootDirectory = "Content/Assets";
            mainTextFont = cm.Load<BitmapFont>("Fonts/PressPlayFont");
        }
	}
}

