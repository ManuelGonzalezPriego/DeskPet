using System.Collections;
using UnityEngine;
public class Pet : MonoBehaviour
{
    private Vector2 direccion;
    private bool stoped = false;
    private PetStats stats;

    // Check how to make the pet clickable
    void OnMouseDown()
    {
        Debug.Log("Pet clicked!");
        StartCoroutine(StopBoing(1f));
    }

    private void Start()
    {
        // Sprite[] skin = Resources.LoadAll<Sprite>("Images/toto");
        // // Initialize the pet stats with default values, this is a example, need to be changed
        // stats = new PetStats(name,skin[Random.Range(0, skin.Length)]);

        // SpriteRenderer sr = GetComponent<SpriteRenderer>();
        // sr.sprite = stats.Skin;
        // transform.localScale = new Vector3(1f, 1f, 1f);

        // 1. Cargar evolución desde JSON
        EvolutionLoader loader = new EvolutionLoader();
        EvolutionTree tree = loader.LoadEvolutionTree();

        // 2. Asignar género aleatorio
        Gender randomGender = (Gender)Random.Range(0, 2);

        // 3. Buscar el nodo correspondiente (EggBoy o EggGirl)
        string eggId = randomGender == Gender.Boy ? "EggBoy" : "EggGirl";
        EvolutionNode eggNode = tree.nodes.Find(n => n.id == eggId);

        // 4. Cargar el sprite del huevo desde Resources
        Sprite[] sprites = Resources.LoadAll<Sprite>(eggNode.spritePath);
        Sprite selectedSprite = sprites.Length > 0 ? sprites[Random.Range(0, sprites.Length)] : null;

        // 5. Crear stats e instanciar sprite
        stats = new PetStats(name, selectedSprite);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = stats.Skin;
        transform.localScale = new Vector3(1f, 1f, 1f);

        
    }

    private void Update()
    {
        this.RandomMove();
    }

    // Makes the pet move in a direction, unless it's in waiting state
    private void RandomMove()
    {
        if (stoped) return;
        transform.Translate(this.stats.Direction * this.stats.Fast * Time.deltaTime);
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
 