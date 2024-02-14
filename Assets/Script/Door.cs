using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool onDoor;
    public PlayerStats playerStats;
    bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (locked)
            {
                if (playerStats.UseKey())
                {
                    locked = false;
                    Debug.Log("Change scene now");
                }
            }
            else
            {
                Debug.Log("Change scene now");
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("test");
            onDoor = true;
        }
    }
}
