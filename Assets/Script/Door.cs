using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool onDoor;
    public PlayerStats playerStats;
    bool locked = true;

    // Update is called once per frame
    void Update()
    {
        if (onDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (locked)
                {
                    if (playerStats.UseKey())
                    {
                        locked = false;
                        Debug.Log("Change scene now");
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                else
                {
                    Debug.Log("Change scene now");
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                }
            }
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onDoor = false;
        }
    }
}
