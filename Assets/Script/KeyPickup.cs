using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    bool onKey = false;
    GameObject keyObject;
    int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onKey)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                key++;
                Destroy(keyObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            onKey = true;
            keyObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            onKey = false;
            keyObject = null;
        }
    }
}
