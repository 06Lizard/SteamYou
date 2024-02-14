using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage = 1;
    public GameObject swordPickupPrefab;
    public Transform SwordTrans;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void FixedUpdate()
    {
        /*if (Swordvelocity = 0)
        {
            BecomePickup();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
        collision.gameObject.GetComponent<EnemyTmpScipt>().TakeDamage(Damage);
        }
        catch { }
        BecomePickup();
    }

    private void BecomePickup()
    {
        Instantiate(swordPickupPrefab, SwordTrans.position, SwordTrans.rotation);
        Destroy(gameObject);
    }
}
