using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float initialMovementSpeed;
    private float movementSpeed;
    [SerializeField] private int damage;

    [SerializeField] private bool touchingPlayer = false;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = initialMovementSpeed;
    }

    private void FixedUpdate() {
        Transform playerTransform = GameManager.Instance.PlayerTransform; // transform del jugador
        Vector2 dir = (playerTransform.position - transform.position).normalized;
        Vector2 movement = dir * movementSpeed;


        if (!touchingPlayer) {
            rb.velocity = movement;
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            touchingPlayer = true;
            HealthSystem playerHealth = collision.GetComponentInChildren<HealthSystem>();
            if (playerHealth.IsVulnerable)
                playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            touchingPlayer = false;
        }
    }

}
