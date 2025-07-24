using System.Collections;
using UnityEngine;
public class Pet : MonoBehaviour
{
    public string DEFAULTNAME = "Pet";
    public int MAXLIFE = 100;
    public int MAXAGE = 18;
    public int MAXAPINES = 100;
    private Vector2 direccion;
    private bool stoped = false;
    private float fast = 1f;

    private PetStats stats;

    private void Start()
    {
        // Initialize the pet stats with default values, this is a example, need to be changed
        stats = new PetStats(DEFAULTNAME, 0, MAXLIFE, MAXAPINES);

        direccion = new Vector2(1, 0.3f).normalized;
    }

    private void Update()
    {
        this.RandomMove();
    }

    // Makes the pet move in a direction, unless it's in waiting state
    private void RandomMove()
    {
        if (stoped) return;

        transform.Translate(direccion * fast * Time.deltaTime);
    }

    // Check how to make the pet clickable
    private void OnMouseDown()
    {
        Debug.Log("Pet clicked!");
        StartCoroutine(StopBoing(1f));
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stoped) return;


        // Invert direction on X axis if hitting wall from left/right
        if (Mathf.Abs(collision.contacts[0].normal.x) > 0.5f)
        {
            direccion.x *= -1;

            // Flip the sprite horizontally to face the new direction
            Vector3 escala = transform.localScale;
            escala.x = Mathf.Sign(direccion.x) * Mathf.Abs(escala.x);
            transform.localScale = escala;
        }

        // Invert direction on Y axis if hitting floor or ceiling
        if (Mathf.Abs(collision.contacts[0].normal.y) > 0.5f)
        {
            direccion.y *= -1;
        }

        // Short delay to prevent rapid flipping
        StartCoroutine(StopBoing(0.05f));
    }

    // Waits briefly after a bounce to prevent double collision processing
    private IEnumerator StopBoing(float secons)
    {
        stoped = true;
        yield return new WaitForSeconds(secons); 
        stoped = false;
    }
}
 