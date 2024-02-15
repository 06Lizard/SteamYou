using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerHealth;
    int health = 1;
    int attackDistance = 2; //How far away the enemy can hit the player from
    int Damage = 1;
    float time = 0;
    float attackSpeed = 2; //Changes the speed of which the enemy can attack
    float moveSpeed = 2;

    float detectDistance = 30; //How far away the enemy will start to detect the player

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        float num = a.x - b.x;
        float num2 = a.y - b.y;
        float num3 = a.z - b.z;
        float distance = (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
        MoveEnemy(distance, num, num2);
    }

    void MoveEnemy(float distance, float num, float num2)
    {
        if (distance < detectDistance)
        {
            if (num > attackDistance || num < -attackDistance)
            {
                float[] moveXY = UpdateMoveSpeed(num, num2);

                RaycastHit2D rayDownRight = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), Vector3.down, 10);
                RaycastHit2D rayDownLeft = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), Vector3.down, 10);

                if (moveXY[0] > 0)
                {
                    if (rayDownRight)
                    {
                        RaycastHit2D rayRight = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), Vector3.down, 1);
                        if (rayRight)
                        {
                            if (rayRight.transform.rotation.z != 90 || rayRight.transform.rotation.z != -90)
                            {
                                transform.position += new Vector3(moveXY[0], moveXY[1]) * Time.deltaTime;
                            }
                        }
                        else
                        {
                            transform.position += new Vector3(moveXY[0], moveXY[1]) * Time.deltaTime;
                        }

                    }
                }
                else
                {
                    if (rayDownLeft)
                    {
                        RaycastHit2D rayLeft = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), Vector3.down, 1);

                        if (rayLeft)
                        {
                            if (rayLeft.transform.rotation.z != 90 || rayLeft.transform.rotation.z != -90)
                            {
                                transform.position += new Vector3(moveXY[0], moveXY[1]) * Time.deltaTime;
                            }
                        }
                        else
                        {
                            transform.position += new Vector3(moveXY[0], moveXY[1]) * Time.deltaTime;
                        }
                    }
                }
            }
            else
            {
                time += Time.deltaTime;
                if (num2 < attackDistance && num2 > -attackDistance && time > attackSpeed)
                {
                    Attack();
                    time = 0;
                }
            }
        }
    }

    float[] UpdateMoveSpeed(float num, float num2)
    {
        float[] moveXY = new float[2];
        if (num > 0)
        {
            moveXY[0] = moveSpeed * (float)Math.Cos(transform.rotation.z);
        }
        else
        {
            moveXY[0] = -moveSpeed * (float)Math.Cos(transform.rotation.z);
        }
        if (num2 > 0)
        {
            moveXY[1] = moveSpeed * (float)Math.Sin(transform.rotation.z);
        }
        else
        {
            moveXY[1] = -moveSpeed * (float)Math.Sin(transform.rotation.z);
        }
        return moveXY;
    }

    void Attack()
    {
        player.gameObject.GetComponent<PlayerStats>().TakeDamage(Damage); // changed the mele attack so that the player can actually take damage
        Debug.Log("Attack");
    }
}