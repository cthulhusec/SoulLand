using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.BitmapFonts;
using SoulLand.Util;

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


		public MenuState mState;
		bool resumeAble = false;
		Vector2 selectionPos;
		KeyboardState oldState;
        float audioVol = 1;
        int selection = 0;

		BitmapFont mainTextFont;

        CachedSound click;

        public MainMenuState (MainGame g) : base(g)
		{
			game = g;
			graphics = game.graphics;
			resumeAble = (game.gameData.world != null);
			mState = MenuState.main;
			oldState = Keyboard.GetState ();
			if (!resumeAble)
			{
				selection = 1;
			}
            click = new CachedSound("Content/Assets/Sound/ClickEffect.mp3");

            audioVol = game.gameData.audioVolume;

        }

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();

			switch (mState) {
			case MenuState.main:
				    if (newState.IsKeyDown(Keys.S) && oldState.IsKeyDown(Keys.S) != true) {
                        AudioEngine.Instance.PlaySound(click);
					    selection += 1;
					    if (!resumeAble)
					    {
						    selection = MathHelper.Clamp(selection, 1, 4);
					    }
					    else
					    {
						    selection = MathHelper.Clamp(selection, 0, 4);
					    }
				    }

				    else if (Keyboard.GetState ().IsKeyDown (Keys.W) && oldState.IsKeyDown(Keys.W) != true) {
                        AudioEngine.Instance.PlaySound(click);
                        selection -= 1;
					    if (!resumeAble)
					    {
						    selection = MathHelper.Clamp(selection, 1, 4);
					    }
					    else
					    {
						    selection = MathHelper.Clamp(selection, 0, 4);
					    }
				    }

                        if (newState.IsKeyDown (Keys.Enter) && oldState.IsKeyDown (Keys.Enter) != true) {
                            AudioEngine.Instance.PlaySound(click);
                        switch (selection) {
					        case 0:
						        game.gameData.load = true;
						        game.ChangeState (MainGame.GameState.Level);
						        break;
					        case 1:
						        game.gameData.load = false;
						        game.gameData = new GameData ();
						        SaveSystem.SaveGameData (game.gameData);
						        game.ChangeState (MainGame.GameState.Level);
						        break;
					        case 2:
						        mState = MenuState.options;
                                selection = 0;
						        break;
					        case 3:
                                mState = MenuState.credits;
						        break;
                            case 4:
                                game.Exit();
                                break;
					    }
				    }
				    break;
                case MenuState.options:
                    if (newState.IsKeyDown(Keys.S) && oldState.IsKeyDown(Keys.S) != true)
                    {
                        AudioEngine.Instance.PlaySound(click);
                        selection += 1;
                        selection = MathHelper.Clamp(selection, 0, 2);
                    }

                    else if (Keyboard.GetState().IsKeyDown(Keys.W) && oldState.IsKeyDown(Keys.W) != true)
                    {
                        AudioEngine.Instance.PlaySound(click);
                        selection -= 1;
                        selection = MathHelper.Clamp(selection, 0, 2);
                    }
                    switch (selection)
                    {
                        case 0:
                            if (newState.IsKeyDown(Keys.D) && oldState.IsKeyDown(Keys.D) != true)
                            {
                                AudioEngine.Instance.PlaySound(click);
                                audioVol += .1f;
                                audioVol = MathHelper.Clamp(audioVol, 0, 1);
                                game.ChangeVolume(audioVol);
                            }
                            if (newState.IsKeyDown(Keys.A) && oldState.IsKeyDown(Keys.A) != true)
                            {
                                AudioEngine.Instance.PlaySound(click);
                                audioVol -= .1f;
                                audioVol = MathHelper.Clamp(audioVol, 0, 1);
                                game.ChangeVolume(audioVol);
                            }
                            break;
                        case 1:
                            if (newState.IsKeyDown(Keys.Enter) && oldState.IsKeyDown(Keys.Enter) != true)
                            {
                                AudioEngine.Instance.PlaySound(click);
                                game.ChangeState(MainGame.GameState.Help);
                            }
                            break;
                    }
                    break;
                case MenuState.credits:

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) && oldState.IsKeyDown(Keys.Enter) != true)
                    {
                        AudioEngine.Instance.PlaySound(click);
                        if (mState == MenuState.credits)
                        {
                            mState = MenuState.main;
                        }
                    }
                    break;

            }
			oldState = newState;
		}

		public override void Draw(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();
			//spriteBatch.Begin (transformMatrix: ((MainGame)game).viewportAdapter.GetScaleMatrix());
			spriteBatch.Begin(transformMatrix: game.globalTransformation);
			//draw title
			//MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch,new MonoGame.Extended.Shapes.RectangleF(game.baseScreenSize.X/2-450,game.baseScreenSize.Y/20,800,150),Color.BlueViolet,10);
			spriteBatch.DrawString(mainTextFont, "SOUL LAND", new Vector2(game.baseScreenSize.X / 2-(mainTextFont.MeasureString("Soul Land") / 2).X, game.baseScreenSize.Y / 20), Color.Fuchsia );


			selectionPos = new Vector2 (game.baseScreenSize.X / 2-175, game.baseScreenSize.Y/ 20 + 275);

			switch (mState) {
			case MenuState.main:
					if (!resumeAble)
					{
					spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.DarkGray);
					}
					else if (selection == 0 && resumeAble)
					{
					spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.White);
					}
					else
					{
					spriteBatch.DrawString(mainTextFont, "Resume Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Resume Game") / 2).X, game.baseScreenSize.Y / 20 + 300), Color.CadetBlue);
					}
					if (selection == 1)
					{
					spriteBatch.DrawString(mainTextFont, "New Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("New Game") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.White);
					}
					else
					{
					spriteBatch.DrawString(mainTextFont, "New Game", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("New Game") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.CadetBlue);
					}
					if (selection == 2)
					{
					spriteBatch.DrawString(mainTextFont, "Options", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Options") / 2).X, game.baseScreenSize.Y / 20 + 600), Color.White);
					}
					else
					{
					spriteBatch.DrawString(mainTextFont, "Options", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Options") / 2).X, game.baseScreenSize.Y / 20 + 600), Color.CadetBlue);
					}
                    if (selection == 3)
                    {
                        spriteBatch.DrawString(mainTextFont, "Credits", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Credits") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(mainTextFont, "Credits", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Credits") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.CadetBlue);
                    }
                    if (selection == 4)
                    {
                        spriteBatch.DrawString(mainTextFont, "Quit", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Quit") / 2).X, game.baseScreenSize.Y / 20 + 900), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(mainTextFont, "Quit", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Quit") / 2).X, game.baseScreenSize.Y / 20 + 900), Color.CadetBlue);
                    }
                    break;

			case MenuState.newGame:
                    break;

			case MenuState.options:
                    if (selection == 0)
                    {
                        spriteBatch.DrawString(mainTextFont, "Audio Volume: " + Math.Round((audioVol * 10)), new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Audio Volume:") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(mainTextFont, "Audio Volume: " + Math.Round((audioVol * 10)), new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Audio Volume:") / 2).X, game.baseScreenSize.Y / 20 + 450), Color.CadetBlue);
                    }

                    if (selection == 1)
                    {
                        spriteBatch.DrawString(mainTextFont, "Controls", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Controls") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(mainTextFont, "Controls", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Controls") / 2).X, game.baseScreenSize.Y / 20 + 750), Color.CadetBlue);
                    }
                    break;

			case MenuState.credits:
				spriteBatch.DrawString(mainTextFont, "Credits:", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Credits:")).X, game.baseScreenSize.Y / 20 + 100), Color.CadetBlue);
				spriteBatch.DrawString(mainTextFont, "Braxton Williams - Project Lead", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Braxton Williams ").X), game.baseScreenSize.Y / 20 + 200), Color.CadetBlue);
				spriteBatch.DrawString(mainTextFont, "Garrett Lackey   - Programmer", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Garrett Lackey   ").X), game.baseScreenSize.Y / 20 + 250), Color.CadetBlue);
				spriteBatch.DrawString(mainTextFont, "Steven Acevedo   - Programmer", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Steven Acevedo   ").X), game.baseScreenSize.Y / 20 + 300), Color.CadetBlue);
				spriteBatch.DrawString(mainTextFont, "Landry Luker     - Level Designer", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Landry Luker     ").X), game.baseScreenSize.Y / 20 + 350), Color.CadetBlue);
				spriteBatch.DrawString(mainTextFont, "Special Thanks:", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Special Thanks:")).X, game.baseScreenSize.Y / 20 + 650), Color.WhiteSmoke);
				spriteBatch.DrawString(mainTextFont, "MonoGame", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("MonoGame").X/2), game.baseScreenSize.Y / 20 + 750), Color.White);
				spriteBatch.DrawString(mainTextFont, "MonoGame Extended", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("MonoGame").X/2), game.baseScreenSize.Y / 20 + 800), Color.White);
				spriteBatch.DrawString(mainTextFont, "Bensounds", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("MonoGame").X/2), game.baseScreenSize.Y / 20 + 850), Color.White);
				spriteBatch.DrawString(mainTextFont, "Free Sounds", new Vector2(game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("MonoGame").X /2), game.baseScreenSize.Y / 20 + 900), Color.White);
				spriteBatch.DrawString(mainTextFont, "Press  ENTER  to continue", new Vector2((game.baseScreenSize.X / 2 - (mainTextFont.MeasureString("Press  ENTER  to continue").X /2)+500), game.baseScreenSize.Y / 20 + 950), Color.Magenta);
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

