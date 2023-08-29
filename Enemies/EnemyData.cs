using Rokuro.Graphics;
using Toutetsu.Items;

namespace Toutetsu.Enemies;

public record EnemyData(string DisplayName, Sprite MapSprite, Sprite FightSprite, StatsSet Stats);
