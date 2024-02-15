using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class RangedEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject fireBall;
    int health = 1;

    List<GameObject> allFireBalls = new List<GameObject>();

    float shootRange = 50; //How far the enemy can detect the player from and start to shoot
    float shootCooldown = 5; //How fast the enemy can shoot
    float time;

    private void Start()
    {
        //Sets so the enemy can shoot right away
        time = shootCooldown;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        float xDis = player.transform.position.x - transform.position.x;
        float yDis = player.transform.position.y - transform.position.y;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        time += Time.deltaTime;
        //Cheks if the player is close enough and that the cooldown is done
        if (distance < shootRange && time >= shootCooldown)
        {
            float yOffset = 0;
            float xOffset = fireBall.transform.localScale.x + 0.5f;
            //Sets the y offset if the x distance is smaller then the y distance
            if (yDis > Math.Sqrt(xDis*xDis)/1.5)
            {
                yOffset = fireBall.transform.localScale.y / 2;
            }
            //Sets the x offset if the x distanse is bigger then zero
            if (xDis < 0)
            {
                xOffset = -(fireBall.transform.localScale.x + 0.5f);
            }
            allFireBalls.Add(Instantiate(fireBall, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset), transform.rotation));

            //Gives the fireball a reference to the player
            allFireBalls[allFireBalls.ToArray().Length - 1].GetComponent<EnemyBullet>().SetPlayerPos(player);
            time = 0;
        }
    }
}
