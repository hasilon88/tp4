using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 0.05f;
    public const float activationDistance = 2.0f;
    private Animator animator;
    private Vector3 direction;

    private HealthBar healthSlider;

    void Start()
    {
        GameObject sliderObject = GameObject.Find("HealthSlider");
        healthSlider = sliderObject.GetComponent<HealthBar>();

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure there's a GameObject with the 'Player' tag.");
        }

        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    void Update()
    {
        if (player != null && animator != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= activationDistance)
            {
                if (distance < 1.0f)
                {
                    Debug.Log("Vous avez frappé un ennemi");
                    healthSlider.TakeDamage(0.05f);
                }
                if (!animator.enabled)
                {
                    animator.enabled = true;
                    Debug.Log("Le joueur s'approche. Activation de l'ennemi.");
                }

                // Move towards the player
                direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(player);

                Debug.Log("Direction towards player: " + direction);
            }
            else
            {
                if (animator.enabled)
                {
                    animator.enabled = false;
                    Debug.Log("Le joueur est trop loin. Désactivation de l'ennemi.");
                }
            }
        }
    }

    // Uncomment if you want to handle collision instead of distance-based damage
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Vous avez frappé un ennemi");
            healthSlider.TakeDamage(5f);
            Destroy(gameObject);
        }
    }
    */
}
