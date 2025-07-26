using UnityEngine;

public class PetStats
{
    private int MAX = 100;
    private int MAXAGE = 18;
    private string name;
    private int age;
    private int life;
    private int apines;
    private bool inHome;
    private bool sickness;
    private int hunger;
    private Gender gender;
    private Sprite skin;

    protected virtual float apinesMultiplier => 1f; // Multiplier for apines
    protected virtual float ageMultiplier => 0.05f; // Multiplier for apines
    protected virtual float fast => 0f; // Speed multiplier, can be overridden in subclasses
    protected virtual Vector2 direction => new Vector2(0f, 0f).normalized; // Default direction to the right

    // Constructor
    public PetStats(string name, Sprite skin)
    {
        this.name = name;
        this.age = 0;
        this.life = MAX;
        this.hunger = MAX;
        this.apines = 0;
        this.skin = skin;
        this.gender = (Gender)UnityEngine.Random.Range(0, 2);
        this.inHome = true;
        this.sickness = false;
    }

    // Methods
    public void birthday()
    {
        this.age = Mathf.Clamp(age + 1, 0, MAXAGE);
    }

    public void hapy(int num)
    {
        this.life = Mathf.Clamp(apines + num, 0, MAX);
    }

    public void unhapy()
    {
        this.life = Mathf.Clamp(apines - 1, 0, MAX);
    }

    public void feed(int amount)
    {
        this.hunger = Mathf.Clamp(hunger + amount, 0, MAX);
    }

    public void hungry()
    {
        this.hunger = Mathf.Clamp(hunger - 1, 0, MAX);
    }

    public void medicament()
    {
        this.sickness = false;
    }

    public void sicken()
    {
        this.sickness = true;
    }

    public void health(int medicament)
    {
        this.life = Mathf.Clamp(life + medicament, 0, MAX);
    }

    public void hurt()
    {
        this.life = Mathf.Clamp(life - 1, 0, MAX);
    }

    public void kill()
    {
        this.inHome = true;
    }



    // Geters and Setters
    public string Name { get => name; }
    public int Age { get => age; }
    public int Life { get => life; }
    public int Apines { get => apines; }
    public bool InHome { get => inHome; }
    public bool Sickness { get => sickness; }
    public float Fast { get => fast; }
    public Sprite Skin { get => skin; }
    public Vector2 Direction { get => direction; }
}
