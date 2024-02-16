using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] public float targetCameraSize = 10f; // Adjust this value as needed
    [SerializeField] public GameObject focalPoint;
    [SerializeField] private float transitionDuration = 1.0f; // Duration of the transition
    [SerializeField] private Vector2 endPosition = new Vector2(20f, 5f);
    public Transform FollowPlayerTrans;

    private Coroutine transitionCoroutine;

    public void FocalPointFocus()
    {
        if (virtualCamera != null && focalPoint != null)
        {
            // Start a new transition coroutine if one is not already running
            if (transitionCoroutine == null)
            {
                // Set the initial position of the BossRoomTrigger to the player's position
                transform.position = FollowPlayerTrans.position;
                // Set the virtual camera to follow the BossRoomTrigger
                virtualCamera.Follow = transform;
                // Start the transition coroutine
                transitionCoroutine = StartCoroutine(TransitionToFocus());
            }
        }
    }

    private IEnumerator TransitionToFocus()
    {
        float initialSize = virtualCamera.m_Lens.OrthographicSize;
        Vector3 initialPosition = virtualCamera.transform.position;
        Vector3 endPositionWithZ = new Vector3(endPosition.x, endPosition.y, initialPosition.z);

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration; // Linear interpolation

            // Interpolate the camera's orthographic size
            float targetSize = Mathf.Lerp(initialSize, targetCameraSize, t);
            // Interpolate the camera's position towards the end position
            Vector3 targetPosition = Vector3.Lerp(initialPosition, endPositionWithZ, t);

            // Update camera properties
            virtualCamera.m_Lens.OrthographicSize = targetSize;
            transform.position = targetPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera size and position are set to the target values at the end of the transition
        virtualCamera.m_Lens.OrthographicSize = targetCameraSize;
        virtualCamera.transform.position = endPositionWithZ;

        // Reset the transition coroutine reference
        transitionCoroutine = null;
    }
}
