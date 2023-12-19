using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Components;

public class SpellButton : GameObject, IMouseInteractable
{
	public SpellButton(Camera camera, FightManager fightManager)
	{
		Camera = camera;
		FightManager = fightManager;
	}

	public ItemData? Spell { get; set; }

	FightManager FightManager { get; }

	public bool WasMouseoverHandled { get; set; } = false;

	public bool IsMouseOver(Vector2D mousePosition) =>
		Enabled && Spell != null && Camera != null &&
		mousePosition.X >= Camera.GetScreenPosition(Position).X &&
		mousePosition.X <= Camera.GetScreenPosition(Position).X + Spell.Sprite.GetWidth() * Camera.Scale &&
		mousePosition.Y >= Camera.GetScreenPosition(Position).Y &&
		mousePosition.Y <= Camera.GetScreenPosition(Position).Y + Spell.Sprite.GetHeight() * Camera.Scale;

	public void OnMouseover() {}

	public void OnClick()
	{
		if (Enabled && Spell != null && FightManager.IsSpellCastingEnabled)
			FightManager.DoPlayerAttack(Spell.GetSpellStats());
	}

	public override void Draw()
	{
		if (Enabled && Spell != null && Camera != null)
			Camera.Draw(Spell.Sprite, Position);
	}
}
