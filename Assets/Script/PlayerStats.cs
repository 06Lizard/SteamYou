using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int HP = 3;
    [SerializeField] int Swords = 3;
    [SerializeField] int Keys = 0;
    [SerializeField] private Transform PointLeft;
    [SerializeField] private Transform PointRight;
    [SerializeField] private Transform PlayersTransform;
    public Transform firePoint;
    public GameObject swordProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack"))
            Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayersTransform.position.x > PointRight.position.x ||
            PlayersTransform.position.x < PointLeft.position.x ||
            PlayersTransform.position.y > PointRight.position.y ||
            PlayersTransform.position.y < PointLeft.position.y)
            Die();
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if (HP <= 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("You Died");
        Destroy(gameObject); // Destroy the GameObject to which this script is attached
    }

    private void Attack()
    {
        if (!(Swords <= 0))
        {
            Swords--;
            Instantiate(swordProjectilePrefab, firePoint.position, firePoint.rotation);
        }
        Debug.Log("Attack");
    }

    public void PickupSword()
    {
        Swords++;
    }

    public bool UseKey()
    {
        if (Keys > 0)
        {
            Keys--;
            return true;
        }
        return false;
    }

    public void PickupKey()
    {
        Keys++;
    }
}