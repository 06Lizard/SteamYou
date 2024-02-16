using UnityEngine;

public class InvissWallTriger : MonoBehaviour
{
    public GameObject WallPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(WallPrefab, transform.position + new Vector3(0,-5,0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
