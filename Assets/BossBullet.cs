using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody2D))]
public class BossBullet : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool turquoiseBullet;

    public float bulletSpeed;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    private Transform player;
    private BoxCollider2D boxCollider;
    private AnimatorClipInfo[] clipInfo;

    public float bulletInAirTime = 15f;

    public string animationName;
    public float animationTime;

    public int minDamage;
    public int maxDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boxCollider = GetComponent<BoxCollider2D>();

        // Start rotating towards the player immediately
        StartCoroutine(RotateTowardsPlayer());
        // Destroy the bullet after a certain time
        StartCoroutine(DestroyBullet());
    }

    private void FixedUpdate()
    {
        if (turquoiseBullet)
        {
            // Move forward constantly
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    private IEnumerator RotateTowardsPlayer()
    {
        while (true)
        {
            if (player != null)
            {
                Vector2 direction = (Vector2)player.position - rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                rb.angularVelocity = -rotateAmount * rotateSpeed;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            playerStats.TakeDamage(1);
            StartCoroutine(PlayAnim());
        }
    }

    private IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(animationTime);
        Destroy(gameObject);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletInAirTime);
        Destroy(gameObject);
    }
}
