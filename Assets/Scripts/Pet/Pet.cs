using System;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public string DEFAULTNAME = "Pet";
    public int MAXLIFE = 100;
    public int MAXAGE = 18;
    public int MAXAPINES = 100;

    private PetStats stats;

    void Start()
    {
        // Initialize the pet stats with default values, this is a example, need to be changed
        stats = new PetStats(DEFAULTNAME, 0, MAXLIFE, MAXAPINES);
    }


    private void Update()
    {
        this.RotateAround();
    }

    public float rotationSpeed = 10f;

    void RotateAround()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
