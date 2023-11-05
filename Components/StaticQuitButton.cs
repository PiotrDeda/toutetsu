using Rokuro.Graphics;
using Rokuro.Objects;
using SDL2;

namespace Toutetsu.Components;

public class StaticQuitButton : InteractableObject
{
	public StaticQuitButton(ISprite sprite, Camera camera) : base(sprite, camera) {}

	public override void OnClick() => SDL.SDL_Quit();
}
