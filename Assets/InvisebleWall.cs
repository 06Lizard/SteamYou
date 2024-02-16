using UnityEngine;

public class InvissWallTriger : MonoBehaviour
{
    public GameObject Wall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(Wall, transform.position + new Vector3(-2, 0, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
