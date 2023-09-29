namespace Toutetsu.Items;

public record StatsSet(int MaxHP, int WhiteAttack, int BlackAttack, int WhiteDefense, int BlackDefense,
	int CritChance, int Agility)
{
	public StatsSet() : this(0, 0, 0, 0, 0, 0, 0) {}

	public static StatsSet SpellStats(int whiteAttack, int blackAttack, int critChance) =>
		new(0, whiteAttack, blackAttack, 0, 0, critChance, 0);
}
