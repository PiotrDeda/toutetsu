namespace Toutetsu.Items;

public class RandomItemGenerator
{
	static List<List<IItemFactory>> ItemFactories { get; } = new() {
		new List<IItemFactory> {
			new SimpleEquippableItemFactory("wooden_wand", ItemType.Weapon,
				new StatsSet(0, 5, 0, 0, 0, 1, 0), new StatsSet(0, 2, 0, 0, 0, 1, 0))
		}
	};

	public static ItemData Generate() => ItemFactories[0][0].Create();
}
