using Rokuro.Core;
using Rokuro.Graphics;

namespace Toutetsu.Items;

public class ItemRegister
{
	public ItemRegister(SpriteManager spriteManager, RNG rng)
	{
		SpriteManager = spriteManager;
		RNG = rng;
	}

	SpriteManager SpriteManager { get; }
	RNG RNG { get; }
	Dictionary<string, IItemTemplate> ItemTemplates { get; } = new();

	public void LoadItemData()
	{
		// TODO: Switch to YAML files?
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
				SimpleEquippableItemTemplate.FromToml(File.ReadAllText($"assets/data/items/{t.Value}.toml"), t.Key,
					SpriteManager, RNG).ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));

			SimpleSpellItemTemplate.FromToml(File.ReadAllText("assets/data/items/spells.toml"), SpriteManager)
				.ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load items: {e.Message}");
		}
	}

	public ItemData CreateItem(string id)
	{
		if (ItemTemplates.TryGetValue(id, out IItemTemplate? template))
			return template.Create();

		Logger.LogWarning($"Item \"{id}\" not found");
		return new BlankItem(SpriteManager);
	}
}
