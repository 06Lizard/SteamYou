using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTmpScipt : MonoBehaviour
{
    int HP = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Damage) 
    {
        HP -= Damage;
        if (HP <= 0)
            Destroy(gameObject); // Destroy the GameObject to which this script is attached
    }
}
