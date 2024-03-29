using Rokuro.Core;
using Rokuro.Objects;
using Toutetsu.Items;

namespace Toutetsu.State;

public class PlayerStats
{
	int _currentHP = 100;
	StatsSet _currentStats = new(100, 0, 0, 0, 0, 1, 1);

	public StatsSet BaseStats { get; } = new(100, 0, 0, 0, 0, 1, 1);

	public StatsSet CurrentStats
	{
		get => _currentStats;
		set
		{
			_currentStats = value;
			RefreshText();
		}
	}

	public int CurrentHP
	{
		get => _currentHP;
		set
		{
			_currentHP = value;
			RefreshText();
		}
	}

	List<TextObject> SpritesLeft { get; } = new();
	List<TextObject> SpritesRight { get; } = new();

	public void AddViewSprites(TextObject spriteLeft, TextObject spriteRight)
	{
		SpritesLeft.Add(spriteLeft);
		SpritesRight.Add(spriteRight);
		RefreshText();
	}

	public void UpdateStats(List<ItemData> items)
	{
		var sortedItems = items.OrderByDescending(o => o.Priority).ToList();
		CurrentStats = BaseStats;
		foreach (ItemData item in sortedItems)
			CurrentStats = item.ApplyStatModifiers(CurrentStats);
		RefreshText();
	}

	public void TakeDamage(StatsSet enemyStats)
	{
		int totalDamage = CalculateDamage(enemyStats.WhiteAttack, CurrentStats.WhiteDefense) +
						  CalculateDamage(enemyStats.BlackAttack, CurrentStats.BlackDefense);

		if (RNG.Rand.Next(100) < enemyStats.CritChance)
			totalDamage *= 2;

		CurrentHP -= totalDamage;

		RefreshText();
	}

	public int DealDamage(StatsSet spellStats, StatsSet enemyStats)
	{
		int totalDamage = CalculateDamage(CurrentStats.WhiteAttack + spellStats.WhiteAttack, enemyStats.WhiteDefense) +
						  CalculateDamage(CurrentStats.BlackAttack + spellStats.BlackAttack, enemyStats.BlackDefense);

		if (RNG.Rand.Next(100) < CurrentStats.CritChance)
			totalDamage *= 2;

		return totalDamage;
	}

	public void FullHeal() => CurrentHP = CurrentStats.MaxHP;

	void RefreshText()
	{
		string textLeft = $"{CurrentHP} / {CurrentStats.MaxHP}\n{CurrentStats.WhiteAttack}\n" +
						  $"{CurrentStats.WhiteDefense}\n{CurrentStats.CritChance}";

		foreach (TextObject sprite in SpritesLeft)
			sprite.Text = textLeft;

		string textRight = $"{CurrentStats.BlackAttack}\n{CurrentStats.BlackDefense}\n{CurrentStats.Agility}";

		foreach (TextObject sprite in SpritesRight)
			sprite.Text = textRight;
	}

	int CalculateDamage(int attack, int defense) =>
		attack < defense ? attack * attack / (2 * defense) : attack - defense / 2;
}
