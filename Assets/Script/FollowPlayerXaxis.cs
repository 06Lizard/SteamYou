using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerXaxis : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] public float minX = -19f;
    [SerializeField] public float maxX = -1f;
    [SerializeField] private bool boss = false;
    public BossRoomTrigger BossRoomTrigger;

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // Get the current position of the camera
            Vector3 newPosition = transform.position;

            // Set the new position's x-coordinate to the player's x-coordinate
            newPosition.x = Mathf.Clamp(playerTransform.position.x, minX, maxX);

            // Update the position of the camera
            transform.position = newPosition;

            if(boss && (newPosition.x >= maxX))
            {
                BossRoomTrigger.FocalPointFocus();
            }
        }
    }
}
