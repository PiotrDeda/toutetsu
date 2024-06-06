using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.Objects;
using Rokuro.Physics;
using Toutetsu.Components;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneDebug : Scene
{
	public override void OnLoaded()
	{
		PlayButton playButton = new() {
			Name = "Play Button",
			Position = new(482, 317),
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/play_button"),
			Camera = GetCamera("Camera"),
			PhysicsObject = new() {
				Position = new(482, 317),
				Hitboxes = {
					new RectHitbox {
						Offset = new(158, 36),
						Position = new(640, 353),
						HalfSize = new(158, 36)
					}
				}
			}
		};
		RegisterGameObject(playButton);

		QuitButton quitButton = new() {
			Name = "Quit Button",
			Position = new(482, 445),
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/quit_button"),
			Camera = GetCamera("Camera"),
			PhysicsObject = new() {
				Position = new(482, 445),
				Hitboxes = {
					new RectHitbox {
						Offset = new(158, 36),
						Position = new(640, 481),
						HalfSize = new(158, 36)
					}
				}
			}
		};
		RegisterGameObject(quitButton);

		Random random = new();
		foreach (int i in Enumerable.Range(0, 10))
		{
			int y = random.Next(100, 800);
			GameObject ball = new() {
				Name = $"Ball {i}",
				Position = new(1000, y),
				Sprite = SpriteManager.CreateSprite<StaticSprite>("debug/ball"),
				Camera = GetCamera("Camera"),
				PhysicsObject = new() {
					Position = new(1000, y),
					Hitboxes = {
						new CircleHitbox {
							Offset = new(32, 32),
							Position = new(1032, y + 32),
							Radius = 32
						}
					}
				}
			};
			RegisterGameObject(ball);
		}

		GameObject boundingBoxTop = new() {
			Name = "Bounding Box Top",
			Position = new(0, 0),
			PhysicsObject = new() {
				Position = new(0, 0),
				Elasticity = 0,
				Hitboxes = {
					new RectHitbox {
						Offset = new(640, 5),
						Position = new(640, 5),
						HalfSize = new(640, 5)
					}
				}
			}
		};
		boundingBoxTop.PhysicsObject.Mass = 0;
		RegisterGameObject(boundingBoxTop);

		GameObject boundingBoxBottom = new() {
			Name = "Bounding Box Bottom",
			Position = new(0, 710),
			PhysicsObject = new() {
				Position = new(0, 710),
				Elasticity = 0,
				Hitboxes = {
					new RectHitbox {
						Offset = new(640, 5),
						Position = new(640, 715),
						HalfSize = new(640, 5)
					}
				}
			}
		};
		boundingBoxBottom.PhysicsObject.Mass = 0;
		RegisterGameObject(boundingBoxBottom);

		GameObject boundingBoxLeft = new() {
			Name = "Bounding Box Left",
			Position = new(0, 10),
			PhysicsObject = new() {
				Position = new(0, 10),
				Elasticity = 0,
				Hitboxes = {
					new RectHitbox {
						Offset = new(5, 350),
						Position = new(5, 360),
						HalfSize = new(5, 350)
					}
				}
			}
		};
		boundingBoxLeft.PhysicsObject.Mass = 0;
		RegisterGameObject(boundingBoxLeft);

		GameObject boundingBoxRight = new() {
			Name = "Bounding Box Right",
			Position = new(1270, 10),
			PhysicsObject = new() {
				Position = new(1270, 10),
				Elasticity = 0,
				Hitboxes = {
					new RectHitbox {
						Offset = new(5, 350),
						Position = new(1275, 360),
						HalfSize = new(5, 350)
					}
				}
			}
		};
		boundingBoxRight.PhysicsObject.Mass = 0;
		RegisterGameObject(boundingBoxRight);

		Input.KeyDownEvent += HandleKeyDown;
		App.Gravity = 0;
	}

	public override void OnEnter()
	{
		GetGameObject("Play Button").PhysicsObject?.ApplyForce(new(400, 400));
		GetGameObject("Quit Button").PhysicsObject?.ApplyForce(new(-400, -400));
		Random random = new();
		foreach (int i in Enumerable.Range(0, 10))
			GetGameObject($"Ball {i}").PhysicsObject?.ApplyForce(new(random.Next(-100, 100), random.Next(-100, 100)));
	}

	public void HandleKeyDown(object? sender, KeyDownEventArgs e)
	{
		if (e.KeyEvent == KeyEvents.CenterCamera)
			App.Gravity = App.Gravity == 0 ? 9.81f : 0;
	}
}
