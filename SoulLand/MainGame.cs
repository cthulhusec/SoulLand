using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace SoulLand
{
	public class MainGame : Game
	{

		public GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public ScalingViewportAdapter viewportAdapter;

		//Game States
		public enum GameState
		{
			Intro,
			MainMenu,
			Level
		}
		//Stores current state enum
		public GameState gs;
		//State Object - "Scene"
		public State state;

		//Logger Singleton
		Logger GameLog;

		public Vector2 baseScreenSize = new Vector2(1920, 1080);

		public Matrix globalTransformation;

		public GameData gameData;

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

			state = new LevelState(this);
			gs = GameState.Level;

			ChangeState (GameState.MainMenu);
			this.graphics.PreferredBackBufferWidth = 1920;
			this.graphics.PreferredBackBufferHeight = 1080;	
			this.graphics.ToggleFullScreen ();
			this.graphics.ApplyChanges ();

			//viewportAdapter = new ScalingViewportAdapter (GraphicsDevice, 1920, 1080);
			//GraphicsDevice.Viewport = new Viewport(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
			//viewportAdapter.Reset ();

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
				case GameState.MainMenu:
					state.Update (gameTime);
					break;
			}

					


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Beige);


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
					state.Draw (gameTime);
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
			}



		}
	}
}

