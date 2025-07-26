using UnityEngine;
using UnityEngine.PlayerLoop;

public class PetStatsEmo : PetStats
{
    public PetStatsEmo(string name, Sprite skin) : base(name, skin) { }
    protected override float apinesMultiplier => 0.8f; 
    protected override float ageMultiplier => 1f;
    protected override float fast => 1f; // Speed multiplier for Emo pet
    protected override Vector2 direction => new Vector2(1f, 0.2f).normalized;    

}
