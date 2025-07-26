using UnityEngine;
using UnityEngine.PlayerLoop;

public class PetStatsHapy : PetStats
{
    public PetStatsHapy(string name, Sprite skin) : base(name, skin) { }
    
    protected override float apinesMultiplier => 2f;
    protected override float ageMultiplier => 1f;
    protected override float fast => 2f; // Speed multiplier for Hapy pet
    protected override Vector2 direction => new Vector2(1f, 0.6f).normalized; 

}
