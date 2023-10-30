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
		try
		{
			SimpleEquippableItemTemplate.FromYaml(File.ReadAllText("assets/data/items.yaml"), SpriteManager, RNG)
				.ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));

			SimpleSpellItemTemplate.FromYaml(File.ReadAllText("assets/data/spells.yaml"), SpriteManager)
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
