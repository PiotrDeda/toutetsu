using Rokuro.Graphics;
using Toutetsu.Items;

namespace Toutetsu.Enemies;

public record EnemyData(string DisplayName, ISprite MapSprite, ISprite FightSprite, StatsSet Stats);
