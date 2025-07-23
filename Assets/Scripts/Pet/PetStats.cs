using UnityEngine;

public class PetStats
{
    private string name;
    private int age;
    private int life;
    private int apines;
    private bool inHome;
    private bool sickness;

    // Constructor
    public PetStats(string name, int age, int life, int apines)
    {
        this.name = name;
        this.age = age;
        this.life = life;
        this.apines = apines;
        this.inHome = true;
        this.sickness = false;
    }

    // Methods

    // Geters and Setters
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public int Life { get => life; set => life = value; }
    public int Apines { get => apines; set => apines = value; }
    public bool InHome { get => inHome; set => inHome = value; }
    public bool Sickness { get => sickness; set => sickness = value; }
}
