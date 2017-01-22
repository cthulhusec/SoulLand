using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;

namespace SoulLand
{
	public class LevelState : State
	{
		private Camera2D cam;
		private World world;

		KeyboardState oldState;

		public bool showInv = false;

		public LevelState (MainGame g) : base(g)
		{

			var viewPortAdapter = new BoxingViewportAdapter(game.Window, graphics, 1920, 1080);
			cam = new Camera2D(viewPortAdapter);
			world = game.gameData.world;
			cam.Zoom = 1f;
			cam.MaximumZoom = 2f;
			cam.MinimumZoom = 0.5f;


		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();

			if (!showInv) {
				
				if (Keyboard.GetState ().IsKeyDown (Keys.A) && oldState.IsKeyDown (Keys.A) != true && game.gameData.player.posx - 1 >= 0) {
					//cam.Move(new Vector2(-5, 0));
					if (world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].wall) {

					} else if (world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].door) {
						world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].OpenDoor (game.gameData.inv);
					} else {
						game.gameData.player.posx -= 1;
					}
				}
				if (Keyboard.GetState ().IsKeyDown (Keys.D) && oldState.IsKeyDown (Keys.D) != true && game.gameData.player.posx + 1 < world.worldGrid.GetLength (1)) {
					//cam.Move(new Vector2(5, 0));
					if (world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].wall) {

					} else if (world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].door) {
						world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].OpenDoor (game.gameData.inv);
					} else {
						game.gameData.player.posx += 1;
					}

				}
				if (Keyboard.GetState ().IsKeyDown (Keys.W) && oldState.IsKeyDown (Keys.W) != true && game.gameData.player.posy - 1 >= 0) {
					//cam.Move(new Vector2(0, -5));
					if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].wall) {

					} else if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].door) {
						world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].OpenDoor (game.gameData.inv);
					} else {
						game.gameData.player.posy -= 1;
					}

				}
				if (Keyboard.GetState ().IsKeyDown (Keys.S) && oldState.IsKeyDown (Keys.S) != true && game.gameData.player.posy + 1 < world.worldGrid.GetLength (0)) {
					//cam.Move(new Vector2(0, 5));
					if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].wall) {

					} else if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].door) {
						world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].OpenDoor (game.gameData.inv);
					} else {
						game.gameData.player.posy += 1;
					}
				}

				if (Keyboard.GetState ().IsKeyDown (Keys.E) && oldState.IsKeyDown (Keys.E) != true) {
					cam.ZoomIn (0.5f);
				}
				if (Keyboard.GetState ().IsKeyDown (Keys.Q) && oldState.IsKeyDown (Keys.Q) != true) {
					cam.ZoomOut (0.5f);
				}

				if (Keyboard.GetState ().IsKeyDown (Keys.F) && oldState.IsKeyDown (Keys.F) != true) {
					if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy].item != null) {
						game.gameData.inv.AddItem (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy].item);
						world.worldGrid [game.gameData.player.posx, game.gameData.player.posy].item = null;
					}
				}

				if (Keyboard.GetState ().IsKeyDown (Keys.I) && oldState.IsKeyDown (Keys.I) != true) {
					showInv = true;
				}
					
				cam.Position = new Vector2 ((game.gameData.player.posx * 20 + 10) - 960, (game.gameData.player.posy * 20 + 10) - 540);
			} else {
				if (Keyboard.GetState ().IsKeyDown (Keys.I) && oldState.IsKeyDown (Keys.I) != true) {
					showInv = false;
				}

			}
			oldState = newState;
		}

		public override void Draw(GameTime gameTime)
		{
			if (!showInv) {
				
				var transformMatrix = cam.GetViewMatrix ();
				transformMatrix *= game.globalTransformation;
				spriteBatch.Begin (transformMatrix: transformMatrix);

				for (int r = 0; r < world.worldGrid.GetLength (0); r++) {
					for (int c = 0; c < world.worldGrid.GetLength (1); c++) {
						if (world.worldGrid [r, c].wall) {
							MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.Black, 10);
						} else if (world.worldGrid [r, c].door) {
							MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.White, 10);
						} else {
							MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.Gray, 10);
							if (world.worldGrid [r, c].item != null) {
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.HotPink, thickness: 10);
							} else if (world.worldGrid [r, c].mob != null) {
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.Green, thickness: 10);
							}
						}
					}
				}

				if (game.gameData.inv.ContainsItem ()) {
					MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (game.gameData.player.posx * 20 + 10, game.gameData.player.posy * 20 + 10), 10), sides: 50, color: Color.DarkBlue, thickness: 10);
				} else {
					MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (game.gameData.player.posx * 20 + 10, game.gameData.player.posy * 20 + 10), 10), sides: 50, color: Color.Aquamarine, thickness: 10);
				}


				spriteBatch.End ();
			} else {
				Inventory inv = game.gameData.inv;
				spriteBatch.Begin(transformMatrix: game.globalTransformation);
				//spriteBatch.DrawString(mainTextFont, "SOUL LAND", new Vector2(game.baseScreenSize.X / 2-(mainTextFont.MeasureString("Soul Land") / 2).X, game.baseScreenSize.Y / 20), Color.Plum );
				for(int i = 0; i<inv.items.Count;i++){
					
				}

			}
		}

		protected override void LoadContent()
		{

		}
	}
}

