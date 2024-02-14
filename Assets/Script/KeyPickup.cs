using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    bool CanBePickedUp = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanBePickedUp && collision.tag == "Player")
        {
            CanBePickedUp = false;
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStats>().PickupKey();
        }
    }
}
