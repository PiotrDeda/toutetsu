using Rokuro.Graphics;

namespace Toutetsu.Items;

public class ItemData
{
	public virtual StatsSet ApplyStatModifiers(StatsSet stats) => stats;
	public virtual StatsSet GetSpellStats() => new();
	
	public Sprite Sprite { get; set; } = null!;
	public ItemType Type { get; set; } = ItemType.General;
	public int Priority { get; set; } = 1;
}
