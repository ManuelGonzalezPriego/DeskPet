using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
public class Pet : MonoBehaviour
{
    public string DEFAULTNAME = "Pet";
    public int MAXLIFE = 100;
    public int MAXAGE = 18;
    public int MAXAPINES = 100;

    public Transform WallL;
    public Transform WallR;
    private int direccion = 1;
    private bool esperando = false;
    private float velocidad = 2f;

    private PetStats stats;

    void Start()
    {
        // Initialize the pet stats with default values, this is a example, need to be changed
        stats = new PetStats(DEFAULTNAME, 0, MAXLIFE, MAXAPINES);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform == this.WallL || collision.transform == this.WallR)
        {
            Debug.Log("Pet collided with a wall: " + collision.gameObject.name);
            // StartCoroutine((TurnAround()));
        }

        // if (collision.gameObject.CompareTag("Wall"))
        // {
        //     Debug.Log("Pet collided with a wall: " + collision.gameObject.name);
        //     // If the pet collides with a wall, it will change direction
        //     // This is a simple way to simulate a pet moving randomly and use coroutines to handle the waiting time.
        //     if (esperando) return;

        //     // Call the TurnAround coroutine to change direction
        //     StartCoroutine(TurnAround());
        // }
        // else
        // {
        //     Console.WriteLine("Pet hit a wall, changing direction.");
        //     // StartCoroutine((TurnAround()));
        // }
    }

    // This function will change the direction of the pet when it hits a wall and use 
    // IEnumerator to wait a random time before changing direction, this is a simple way to simulate a pet 
    // moving randomly and use coroutines to handle the waiting time.
    private IEnumerator TurnAround(){
        esperando = true;

        // Yield is used to pause the execution of the coroutine
        yield return new WaitForSeconds(0.5f); // Stop for a random time
        direccion *= -1;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
        esperando = false;
    }


    private void Update()
    {
        this.RandomMove();
    }

    // In this fuction, the pet will move randomly between two walls
    private void RandomMove()
    {
        if (esperando) return;

        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);
    }
}
 