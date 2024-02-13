using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBullet : MonoBehaviour
{
    float xMove = 5f;
    float yMove;
    float time;
    float aliveTime = 5;

    public void SetPlayerPos(GameObject player)
    {
        //Gets the x and y distance between the player and bullet
        float xDis = player.transform.position.x - transform.position.x;
        float yDis = player.transform.position.y - transform.position.y;

        //Checks if the player is above the bullet spawn
        if (yDis > 0)
        {
            //Checks if the y distance is bigger then the x distance
            if (yDis > Math.Sqrt(xDis * xDis)/1.5)
            {
                if (xDis < 3)
                {
                    yMove = 5;
                    xMove = 0;
                }
                else if (xDis < 0)
                {
                    yMove = 2.5f;
                    xMove = -2.5f;
                }
                else
                {
                    yMove = 2.5f;
                    xMove = 2.5f;
                }
            }
            else
            {
                xMove = -5f;
                yMove = 0;
            }
        }
        else if (xDis < 0)
        {
            xMove = -xMove;
            yMove = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float bulletTravel = (float)Math.Sqrt((((transform.position.x + xMove) * (transform.position.x+ xMove)) + ((transform.position.y + yMove) * (transform.position.y + yMove))) * Time.deltaTime);

        RaycastHit2D ray;
        if (xMove > 0)
        {
            ray = Physics2D.Raycast(new Vector3(transform.position.x + transform.localScale.magnitude/1.5f, transform.position.y), new Vector2(transform.position.x + xMove, transform.position.y + yMove), bulletTravel);
        }
        else
        {
            ray = Physics2D.Raycast(new Vector3(transform.position.x - transform.localScale.magnitude / 1.5f, transform.position.y), new Vector2(transform.position.x + xMove, transform.position.y + yMove), bulletTravel);
        }
        if (ray)
        {
            Debug.Log(ray.transform.name);
            if (ray.transform.tag == "Player")
            {
                //ray.transform.GetComponent<PlayerStats>().HP--;
            }
            Destroy(gameObject);
        }
        //Moves the bullet
        transform.position += new Vector3(xMove, yMove) * Time.deltaTime;
        
        time += Time.deltaTime;
        //Destroys the bullet after a certain time
        if (time >= aliveTime)
        {
            Destroy(gameObject);
        }
    }
}
