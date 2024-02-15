using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private bool boss = false;
    [SerializeField] private Transform selfTrans;
    [SerializeField] private GameObject BossKeyPrefab;

    private void Start()
    {
        TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            if (boss)
            {
                Instantiate(BossKeyPrefab, selfTrans.position, selfTrans.rotation);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }            
        }
    }
}
