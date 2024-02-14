using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    bool CanBePickedUp = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanBePickedUp)
        {
            CanBePickedUp = false;
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStats>().PickupSword();
        }        
    }
}
