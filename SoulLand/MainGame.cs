using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using SoulLand.Util;
using NAudio.Wave;

namespace SoulLand
{
	public class MainGame : Game
	{

		public GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public ScalingViewportAdapter viewportAdapter;

		KeyboardState oldKeyboardState;

		//Game States
		public enum GameState
		{
			Intro,
			MainMenu,
			Level,
            Help
		}
		//Stores current state enum
		public GameState gs;
		//State Object - "Scene"
		public State state;

		//Logger Singleton
		public Logger GameLog;

		public Vector2 baseScreenSize = new Vector2(1920, 1080);

		public Matrix globalTransformation;

		public GameData gameData;

        public bool resume = false;


        WaveOut waveOut;




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

            GameLog.Log("Initializing Game!");

            this.graphics.PreferredBackBufferWidth = 1920;
			this.graphics.PreferredBackBufferHeight = 1080;
			this.graphics.ToggleFullScreen();
			this.graphics.ApplyChanges();

			gameData = SaveSystem.LoadGameData();
			if (gameData == null) {
				gameData = new GameData ();
			}

			state = new LevelState(this);
			gs = GameState.Level;

			ChangeState (GameState.Intro);

			oldKeyboardState = Keyboard.GetState();

            AudioFileReader reader = new AudioFileReader("Content/Assets/Sound/TechnoBackground.mp3");
            reader.Volume = 0.25F;
            LoopStream loop = new LoopStream(reader);
            waveOut = new WaveOut();
            waveOut.Init(loop);
            
            waveOut.Play();

            ChangeVolume(gameData.audioVolume);




        }

		protected override void LoadContent()
		{
			base.LoadContent();

			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape) && oldKeyboardState.IsKeyDown(Keys.Escape) != true)
			{
				if (gs == GameState.Level && ((LevelState)state).showInv) {
					((LevelState)state).showInv = false;
				} else if (gs == GameState.Level) {
					SaveSystem.SaveGameData (gameData);
					ChangeState (GameState.MainMenu);
				} else {
                    if (gs == GameState.MainMenu && ((MainMenuState)state).mState != MainMenuState.MenuState.main)
                    {
                        ((MainMenuState)state).mState = MainMenuState.MenuState.main;
                    }
                    else
                    {
                        GameLog.Log("Exiting Game!");
                        SaveSystem.SaveGameData(gameData);
                        Exit();
                    }
				}
			}
			switch (gs)
			{
				case GameState.Level:
					state.Update(gameTime);
					break;
				case GameState.MainMenu:
					state.Update (gameTime);
					break;
                case GameState.Intro:
                    state.Update(gameTime);
                    break;
                case GameState.Help:
                    state.Update(gameTime);
                    break;
			}

					
			oldKeyboardState = newState;


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);


			Vector3 screenScalingFactor;
			float horScaling = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / baseScreenSize.X;
			float verScaling = (float)GraphicsDevice.PresentationParameters.BackBufferHeight / baseScreenSize.Y;
			screenScalingFactor = new Vector3(horScaling, verScaling, 1);
			globalTransformation = Matrix.CreateScale(screenScalingFactor);


			switch (gs)
			{
				case GameState.Level:
					state.Draw(gameTime);
					break;
                case GameState.MainMenu:
                    state.Draw(gameTime);
                    break;
                case GameState.Intro:
                    state.Draw(gameTime);
                    break;
                case GameState.Help:
                    state.Draw(gameTime);
                    break;
            }
			base.Draw(gameTime);
		}

		public Logger GetLog()
		{
			return GameLog;
		}

		public void ChangeState(GameState gameState)
		{

            GameLog.Log("State Changed: " + gameState.ToString());

			state.UnLoadContent ();

			switch (gameState)
			{
			case GameState.Level:
				state = new LevelState (this);
				gs = gameState;
					break;
			case GameState.Intro:
				state = new IntroState (this);
				gs = gameState;
					break;
			case GameState.MainMenu:
				state = new MainMenuState (this);
				gs = gameState;
					break;
            case GameState.Help:
                state = new HelpState(this);
                gs = gameState;
                    break;
			}



		}


        public void ChangeVolume(float volume)
        {
            GameLog.Log("Volume Changed: " + volume.ToString());
            gameData.audioVolume = volume;
            SaveSystem.SaveGameData(gameData);
            waveOut.Volume = volume/10;
        }
	}
}

