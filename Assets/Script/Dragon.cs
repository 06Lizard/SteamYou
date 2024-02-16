using UnityEngine;

public class Dragon : MonoBehaviour
{
    private bool Wake = false;
    private Transform playerTransform; // Reference to the player's transform
    public GameObject BossBulletPrefab;
    public float attackSpeed;
    private float nextAttackTime = 0f;
    public float attackDuration = 10f;
    private float attackTimeLeft = 0f;
    public float waitTime = 10f;
    private bool waiting = false;
    private float waitEndTime = 0f;
    private float initialDelay = 3f; // Initial delay before dragon starts moving
    private bool initialDelayComplete = false;
    public float moveSpeed = 5f;
    public float minX = -5f; // Minimum X position for left and right movement
    public float maxX = 5f; // Maximum X position for left and right movement

    public void WakeUpDragon(Transform player)
    {
        Wake = true;
        attackTimeLeft = attackDuration;
        playerTransform = player;
    }

    private void FixedUpdate()
    {
        if (Wake)
        {
            if (!initialDelayComplete)
            {
                // Increment the timer for the initial delay
                initialDelay -= Time.fixedDeltaTime;
                if (initialDelay <= 0f)
                {
                    initialDelayComplete = true;
                    // Reset the timer for subsequent use
                    initialDelay = 3f;
                }
            }
            else
            {
                if (!waiting)
                {
                    // Move left and right while firing
                    float movement = Mathf.PingPong(Time.time * moveSpeed, maxX - minX) + minX;
                    transform.position = new Vector3(movement, transform.position.y, transform.position.z);

                    if (attackTimeLeft > 0)
                    {
                        if (Time.time >= nextAttackTime)
                        {
                            // Fire bullet
                            Instantiate(BossBulletPrefab, transform.position, transform.rotation);
                            // Set the next attack time using the attack speed
                            nextAttackTime = Time.time + 1f / attackSpeed;
                            attackTimeLeft -= Time.fixedDeltaTime;
                        }
                    }
                    else
                    {
                        // Start waiting
                        waiting = true;
                        waitEndTime = Time.time + waitTime;
                    }
                }
                else
                {
                    // Move towards the player while waiting
                    if (playerTransform != null)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.fixedDeltaTime);
                    }

                    // Check if waiting time is over
                    if (Time.time >= waitEndTime)
                    {
                        // Resume attacking
                        waiting = false;
                        attackTimeLeft = attackDuration;
                    }
                }
            }
        }
    }
}
