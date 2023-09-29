using Rokuro.Core;

namespace Toutetsu.Items;

public static class ItemRegister
{
	static Dictionary<string, IItemTemplate> ItemTemplates { get; } = new();

	public static void LoadItemData()
	{
		// TODO: Move reading files TOML engine
		try
		{
			Dictionary<ItemType, string> types = new() {
				{ ItemType.Weapon, "weapons" },
				{ ItemType.Helmet, "helmets" },
				{ ItemType.Armor, "armors" },
				{ ItemType.Boots, "boots" },
				{ ItemType.Trinket, "trinkets" },
				{ ItemType.Shield, "shields" },
				{ ItemType.Book, "books" }
			};

			foreach (KeyValuePair<ItemType, string> t in types)
				SimpleEquippableItemTemplate.FromToml(File.ReadAllText($"assets/data/items/{t.Value}.toml"), t.Key)
					.ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));

			SimpleSpellItemTemplate.FromToml(File.ReadAllText("assets/data/items/spells.toml"))
				.ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load items: {e.Message}");
		}
	}

	public static ItemData CreateItem(string id)
	{
		if (ItemTemplates.TryGetValue(id, out IItemTemplate? template))
			return template.Create();

		Logger.LogWarning($"Item \"{id}\" not found");
		return new BlankItem();
	}
}
