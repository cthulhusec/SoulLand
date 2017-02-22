using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.BitmapFonts;
using System.Collections.Generic;
using SoulLand.Util;

namespace SoulLand
{
	public class LevelState : State
	{
        private Camera2D cam;

		private String tempPos;

        private String referenceText;

		private int tempHealth;

        private int cursorPos;

		KeyboardState oldState;

        BitmapFont mainTextFont;

        public World world;

		public bool showInv = false;

        public bool alive = true;

        CachedSound key = new CachedSound("Content/Assets/Sound/KeyEffect.mp3");

		public LevelState (MainGame g) : base(g)
		{

			var viewPortAdapter = new BoxingViewportAdapter(game.Window, graphics, 1920, 1080);
			cam = new Camera2D(viewPortAdapter);
			world = game.gameData.world;
			cam.Zoom = 2f;
			cam.MaximumZoom = 2f;
			cam.MinimumZoom = 0.5f;
			if (!game.gameData.load) {
                game.gameData.world = new World(20,20);
                world = game.gameData.world;
				tempPos = world.ChangeLevel ();
				String[] temp = tempPos.Split (',');
				game.gameData.player.posx = Int32.Parse (temp [0]);
				game.gameData.player.posy = Int32.Parse (temp [1]);
			}
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState ();

			if (!showInv && alive) {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && oldState.IsKeyDown(Keys.Up) != true)
                {
                    game.gameData.player.Attack(world, 1);
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && oldState.IsKeyDown(Keys.Right) != true)
                {
                    game.gameData.player.Attack(world, 2);
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && oldState.IsKeyDown(Keys.Down) != true)
                {
                    game.gameData.player.Attack(world, 3);
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) && oldState.IsKeyDown(Keys.Left) != true)
                {
                    game.gameData.player.Attack(world, 4);
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                }
                if (Keyboard.GetState ().IsKeyDown (Keys.A) && oldState.IsKeyDown (Keys.A) != true && game.gameData.player.posx - 1 >= 0) {
                    //cam.Move(new Vector2(-5, 0));
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                    if (world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].wall) {

					} else if (world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].door) {
						if(world.worldGrid [game.gameData.player.posx - 1, game.gameData.player.posy].OpenDoor (game.gameData.inv))
                            AudioEngine.Instance.PlaySound(key);
					} else {
						game.gameData.player.posx -= 1;
					}
				}
				if (Keyboard.GetState ().IsKeyDown (Keys.D) && oldState.IsKeyDown (Keys.D) != true && game.gameData.player.posx + 1 < world.worldGrid.GetLength (0)) {
                    //cam.Move(new Vector2(5, 0));
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                    if (world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].wall) {

					} else if (world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].door) {
						if(world.worldGrid [game.gameData.player.posx + 1, game.gameData.player.posy].OpenDoor (game.gameData.inv))
                            AudioEngine.Instance.PlaySound(key);
                    } else {
						game.gameData.player.posx += 1;
					}
				}
				if (Keyboard.GetState ().IsKeyDown (Keys.W) && oldState.IsKeyDown (Keys.W) != true && game.gameData.player.posy - 1 >= 0) {
                    //cam.Move(new Vector2(0, -5));
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    } else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                    if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].wall) {

					} else if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].door) {
						if(world.worldGrid [game.gameData.player.posx, game.gameData.player.posy - 1].OpenDoor (game.gameData.inv))
                            AudioEngine.Instance.PlaySound(key);
                    } else {
						game.gameData.player.posy -= 1;
					}
				}
				if (Keyboard.GetState ().IsKeyDown (Keys.S) && oldState.IsKeyDown (Keys.S) != true && game.gameData.player.posy + 1 < world.worldGrid.GetLength (1)) {
                    //cam.Move(new Vector2(0, 5));
                    if (game.gameData.player.mobWaitMove == 0)
                    {
                        foreach (Mob a in world.mobs.ToArray())
                        {
                            if (world.worldGrid[a.posx, a.posy].renderable <= world.triggerNo)
                            {
                                world = a.MobMove(world, game.gameData.player, a);
                            }
                        }
                        if (world.boss != null)
                        {
                            if (world.worldGrid[world.boss.posx, world.boss.posy].renderable <= world.triggerNo)
                            {
                                world = world.boss.Move(world, game.gameData.player);
                            }
                        }
                        game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                    }
                    else
                    {
                        game.gameData.player.mobWaitMove -= 1;
                    }
                    if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].wall) {

					} else if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].door) {
						if(world.worldGrid [game.gameData.player.posx, game.gameData.player.posy + 1].OpenDoor (game.gameData.inv))
                            AudioEngine.Instance.PlaySound(key);
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
                    cursorPos = 1;
                    referenceText = "Use  W  or  S  to navigate through the inventory.";
                    showInv = true;
				}
					
				cam.Position = new Vector2 ((game.gameData.player.posx * 20 + 10) - 960, (game.gameData.player.posy * 20 + 10) - 540);
			}
            else if (alive)
            {
                Inventory inv = game.gameData.inv;
                if (Keyboard.GetState().IsKeyDown(Keys.W) && oldState.IsKeyDown(Keys.W) != true)
                {
                    if (cursorPos > 1)
                    {
                        referenceText = "Use  W  or  S  to navigate through the inventory.";
                        cursorPos -= 1;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && oldState.IsKeyDown(Keys.S) != true)
                {
                    if (cursorPos < inv.items.Count)
                    {
                        referenceText = "Use  W  or  S  to navigate through the inventory.";
                        cursorPos += 1;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && oldState.IsKeyDown(Keys.Enter) != true)
                {
                    if (cursorPos > 0)
                    {
                        if (inv.items[cursorPos - 1].GetType() == typeof(Charm))
                        {
                            if (inv.items[cursorPos - 1].name.Equals("Delay Mob Attack Charm"))
                            {
                                game.gameData.player.mobWaitAttack++;
                                game.GameLog.Log("Current mobWaitAttack is: " + game.gameData.player.mobWaitAttack.ToString());
                            }
                            else if (inv.items[cursorPos - 1].name.Equals("Double Move Charm"))
                            {
                                game.gameData.player.mobWaitMove++;
                                game.GameLog.Log("Current mobWaitMove is: " + game.gameData.player.mobWaitMove.ToString());
                            }
                            else if (inv.items[cursorPos - 1].name.Equals("Health Charm"))
                            {
                                game.gameData.player.health += 2;
                                game.GameLog.Log("Current health is: " + game.gameData.player.health.ToString());
                            }
                            inv.RemoveItem(cursorPos - 1);
                        }
                        else
                        {
                            referenceText = "This item is not consumable.";
                        }
                    }
                }
				if (Keyboard.GetState ().IsKeyDown (Keys.I) && oldState.IsKeyDown (Keys.I) != true) {
					showInv = false;
				}

			} else
            {
                
            }

			if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy].end == true) {
				tempPos = world.ChangeLevel ();
				String[] temp = tempPos.Split (',');
				game.gameData.player.posx = Int32.Parse (temp [0]);
				game.gameData.player.posy = Int32.Parse (temp [1]);
			} else if (world.worldGrid [game.gameData.player.posx, game.gameData.player.posy].trigger) {
				world.triggerNo += 1;
                world.worldGrid[game.gameData.player.posx, game.gameData.player.posy].trigger = false;
                world.worldGrid[game.gameData.player.posx, game.gameData.player.posy].floor = true;

            }

			oldState = newState;

            if (game.gameData.player.health <= 0)
            {
                game.GameLog.Log("Player Died");
                game.gameData.world = null;
                SaveSystem.SaveGameData(game.gameData);
                alive = false;
            }
		}

		public override void Draw(GameTime gameTime)
		{
			if (!showInv && alive) {
				
				var transformMatrix = cam.GetViewMatrix ();
				transformMatrix *= game.globalTransformation;
				spriteBatch.Begin (transformMatrix: transformMatrix);

				for (int r = 0; r < world.worldGrid.GetLength (0); r++) {
					for (int c = 0; c < world.worldGrid.GetLength (1); c++) {
						if (world.worldGrid [r, c].renderable <= world.triggerNo) {
							if (world.worldGrid [r, c].wall) {
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.DarkSlateGray, 10);
							} else if (world.worldGrid [r, c].end != false) {
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.Gray, 10);
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.OrangeRed, thickness: 10);
							} else if (world.worldGrid [r, c].door) {
								MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle (spriteBatch, new MonoGame.Extended.Shapes.RectangleF (r * 20, c * 20, 20, 20), Color.White, 10);
							} else if (world.worldGrid[r, c].floor || world.worldGrid[r, c].trigger) {
                                MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawRectangle(spriteBatch, new MonoGame.Extended.Shapes.RectangleF(r * 20, c * 20, 20, 20), Color.Gray, 10);
                                if (world.worldGrid [r, c].item != null) {
									MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.HotPink, thickness: 10);
								} else if (world.worldGrid [r, c].mob != null) {
									MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.Green, thickness: 10);
								} else if (world.worldGrid [r, c].boss != null) {
									MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (r * 20 + 10, c * 20 + 10), 10), sides: 50, color: Color.Maroon, thickness: 10);
								} 
							}
						}
					}
				}

                MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle(spriteBatch, new MonoGame.Extended.Shapes.CircleF(new Vector2(game.gameData.player.posx * 20 + 10, game.gameData.player.posy * 20 + 10), 9), sides: 50, color: Color.SlateBlue, thickness: 10);

                spriteBatch.End ();
				spriteBatch.Begin ();

				tempHealth = game.gameData.player.health;
				for (int i = 1; tempHealth > 0; tempHealth -= 1) {
					MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle (spriteBatch, new MonoGame.Extended.Shapes.CircleF (new Vector2 (30 * i, 20), 10), sides: 6, color: Color.OrangeRed, thickness: 10);
					i++;
                }
                if (world.triggerNo <= 1 && world.currentLevel == 1)
                {
                    spriteBatch.DrawString(mainTextFont, "Press  W  A  S  D to move and  F  to pick up items.", new Vector2(30, game.baseScreenSize.Y - 60), Color.AntiqueWhite);
                }
                else if (world.currentLevel == 1)
                {
                    spriteBatch.DrawString(mainTextFont, "Use  ARROW KEYS  to attack mobs.", new Vector2(30, game.baseScreenSize.Y - 60), Color.AntiqueWhite);
                }
                else if (world.currentLevel == 9)
                {
                    spriteBatch.DrawString(mainTextFont, "YOU WIN", new Vector2((game.baseScreenSize.X/2) - (mainTextFont.MeasureString("YOU WIN").X / 2), game.baseScreenSize.Y / 2 - 10), Color.Goldenrod);
                }
                spriteBatch.End();

            } else if (alive) {
				Inventory inv = game.gameData.inv;
				spriteBatch.Begin(transformMatrix: game.globalTransformation);
				//spriteBatch.DrawString(mainTextFont, "SOUL LAND", new Vector2(game.baseScreenSize.X / 2-(mainTextFont.MeasureString("Soul Land") / 2).X, game.baseScreenSize.Y / 20), Color.Plum );
				for(int i = 0; i<inv.items.Count;i++){
                    spriteBatch.DrawString(mainTextFont, inv.items[i].name, new Vector2(60,30*(i + 2)), Color.AntiqueWhite);
				}
                if (inv.items.Count != 0)
                {
                    MonoGame.Extended.Shapes.SpriteBatchExtensions.DrawCircle(spriteBatch, new MonoGame.Extended.Shapes.CircleF(new Vector2(30, 15 + (30 * (cursorPos + 1))), 10), sides: 4, color: Color.AntiqueWhite, thickness: 10);
                    spriteBatch.DrawString(mainTextFont, referenceText, new Vector2(30, game.baseScreenSize.Y - 60), Color.AntiqueWhite);

                }
                else
                {
                    spriteBatch.DrawString(mainTextFont, "Inventory is empty.", new Vector2(30, game.baseScreenSize.Y - 60), Color.AntiqueWhite);

                }
                spriteBatch.End ();

			} else
            {
                spriteBatch.Begin(transformMatrix: game.globalTransformation);
                spriteBatch.DrawString(mainTextFont, "YOU DIED", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("YOU DIED").X / 2), game.baseScreenSize.Y / 2 - 100), Color.Red);
                spriteBatch.DrawString(mainTextFont, "Press  ESCAPE  to return to Main Menu", new Vector2((game.baseScreenSize.X / 2) - (mainTextFont.MeasureString("Press  ESCAPE  to return to Main Menu").X / 2), game.baseScreenSize.Y / 2 + 100), Color.Red);
                spriteBatch.End();
            }
        }

		protected override void LoadContent()
		{
            cm.RootDirectory = "Content/Assets";
            mainTextFont = cm.Load<BitmapFont>("Fonts/PressPlayFont");
        }
	}
}


