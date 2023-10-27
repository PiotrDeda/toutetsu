using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Components;

public class SpellButton : BaseObject, IDrawable, IMouseInteractable
{
	public SpellButton(Camera camera, FightManager fightManager)
	{
		Camera = camera;
		FightManager = fightManager;
	}

	public ItemData? Spell { get; set; }

	Camera Camera { get; }
	FightManager FightManager { get; }

	public void Draw()
	{
		if (Enabled && Spell is not null)
			Camera.Draw(Spell.Sprite, Position);
	}

	public bool WasMouseoverHandled { get; set; } = false;

	public bool IsMouseOver(Vector2D mousePosition) =>
		Enabled && Spell is not null &&
		mousePosition.X >= Camera.GetScreenPosition(Position).X &&
		mousePosition.X <= Camera.GetScreenPosition(Position).X + Spell.Sprite.GetWidth() * Camera.Scale &&
		mousePosition.Y >= Camera.GetScreenPosition(Position).Y &&
		mousePosition.Y <= Camera.GetScreenPosition(Position).Y + Spell.Sprite.GetHeight() * Camera.Scale;

	public void OnMouseover() {}

	public void OnClick()
	{
		if (Enabled && Spell is not null && FightManager.IsSpellCastingEnabled)
			FightManager.DoPlayerAttack(Spell.GetSpellStats());
	}
}
