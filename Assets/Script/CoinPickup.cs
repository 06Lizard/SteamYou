using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public short CoinValue;
    bool CanBePickedUp = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanBePickedUp)
        {
            CanBePickedUp = false;
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStats>().AddToScore(CoinValue);
        }
    }
}
