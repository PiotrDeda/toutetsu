using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Components;

public class SpellButton : InteractableObject
{
	public SpellButton(Camera camera, FightManager fightManager)
	{
		Camera = camera;
		FightManager = fightManager;
	}

	public ItemData? Spell { get; set; }

	FightManager FightManager { get; }

	public override bool IsMouseOver(Vector2I mousePosition) =>
		Enabled && Spell != null && Camera != null &&
		mousePosition.X >= Camera.GetScreenPosition(Position).X &&
		mousePosition.X <= Camera.GetScreenPosition(Position).X + Spell.Sprite.Width * Camera.Scale &&
		mousePosition.Y >= Camera.GetScreenPosition(Position).Y &&
		mousePosition.Y <= Camera.GetScreenPosition(Position).Y + Spell.Sprite.Height * Camera.Scale;

	public override void OnClick()
	{
		if (Enabled && Spell != null && FightManager.IsSpellCastingEnabled)
			FightManager.DoPlayerAttack(Spell.GetSpellStats());
	}

	public override void Draw()
	{
		if (Enabled && Spell != null && Camera != null)
			Camera.DrawSprite(Spell.Sprite, Position);
	}
}
