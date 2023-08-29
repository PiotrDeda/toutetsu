namespace Toutetsu.Items;

public record StatsSet(int MaxHP, int WhiteAttack, int BlackAttack, int WhiteDefense, int BlackDefense,
	int CritChance, int Agility)
{
	public StatsSet() : this(0, 0, 0, 0, 0, 0, 0) {}
}
