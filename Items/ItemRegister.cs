using Rokuro.Core;

namespace Toutetsu.Items;

public class ItemRegister
{
	Dictionary<string, IItemTemplate> ItemTemplates { get; } = new();

	public void LoadItemData()
	{
		try
		{
			SimpleEquippableItemTemplate.FromYaml(File.ReadAllText(Path.Combine("assets", "data", "items.yaml")))
				.ToList().ForEach(x => ItemTemplates.Add(x.Key, x.Value));

			SimpleSpellItemTemplate.FromYaml(File.ReadAllText(Path.Combine("assets", "data", "spells.yaml")))
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

		Logger.ThrowError($"Item \"{id}\" not found");
		return new BlankItem();
	}
}
