using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float targetCameraSize = 10f; // Adjust this value as needed
    [SerializeField] public GameObject FocalPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (virtualCamera != null)
            {
                // Change the follow target of the Cinemachine Virtual Camera to the player
                virtualCamera.Follow = FocalPoint.transform;

                // Linearly scale up the camera size
                StartCoroutine(ScaleCameraSizeOverTime(targetCameraSize));
            }
        }        
    }

    private IEnumerator ScaleCameraSizeOverTime(float targetSize)
    {
        float initialSize = virtualCamera.m_Lens.OrthographicSize;
        float elapsedTime = 0f;
        float duration = 1f; // Adjust the duration of the scaling animation

        while (elapsedTime < duration)
        {
            float newSize = Mathf.Lerp(initialSize, targetSize, elapsedTime / duration);
            virtualCamera.m_Lens.OrthographicSize = newSize;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera size is set to the target size at the end of the animation
        virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}
