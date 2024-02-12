using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int HP = 3;
    [SerializeField] int Swords = 3;
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform PlayersTransform;

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
        if (PlayersTransform.position.x > P2.position.x ||
            PlayersTransform.position.x < P1.position.x ||
            PlayersTransform.position.y > P2.position.y ||
            PlayersTransform.position.y < P1.position.y)
            Die();
    }

    void TakeDamage(int damage)
    {
        HP -= damage;
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
            //SpawnPrefab(lookDirection);
        }
    }
}
