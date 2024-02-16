using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class BossBullet : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool turquoiseBullet;

    public float bulletSpeed;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private AnimatorClipInfo[] clipInfo;

    public float bulletInAirTime = 5f;

    public string animationName;
    public float animationTime;

    public int minDamage;
    public int maxDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boxCollider = GetComponent<BoxCollider2D>();
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
    }
    private void FixedUpdate()
    {
        if (turquoiseBullet)
        {
            TurquoiseBullet();
        }
    }

    private void TurquoiseBullet()
    {
        Vector2 direction = (Vector2)player.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * bulletSpeed;
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
        animator.Play(animationName);
        yield return new WaitForSeconds(animationTime);
        Destroy(gameObject);
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletInAirTime);
        Destroy(gameObject);
    }
}
