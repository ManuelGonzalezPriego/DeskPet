using UnityEngine;
using UnityEngine.PlayerLoop;

public class PetStatsLacy : PetStats
{
    public PetStatsLacy(string name, Sprite skin) : base(name, skin) {}
    
    protected override float apinesMultiplier => 1f;
    protected override float ageMultiplier => 1f;
    protected override float fast => 0.5f; // Speed multiplier for Lacy pet
    protected override Vector2 direction => new Vector2(1f, 0f).normalized;
}
