using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int HP = 3;
    [SerializeField] public int Swords = 3;
    [SerializeField] public int Keys = 0;
    [SerializeField] private Transform PointLeft;
    [SerializeField] private Transform PointRight;
    [SerializeField] private Transform PlayersTransform;
    public Transform firePoint;
    public GameObject swordProjectilePrefab;
    //public int Score = 0;

    private DifficultySelector difficultySelector; // Reference to DifficultySelector script

    void Start()
    {
        // Find and store the DifficultySelector component in the scene
        difficultySelector = FindObjectOfType<DifficultySelector>();
        HP = difficultySelector.initialHP;
        Swords = difficultySelector.initialHP;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack"))
            Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayersTransform.position.x > PointRight.position.x ||
            PlayersTransform.position.x < PointLeft.position.x ||
            PlayersTransform.position.y > PointRight.position.y ||
            PlayersTransform.position.y < PointLeft.position.y)
            Die();
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if (HP <= 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("You Died");
        difficultySelector.Respawns -= 1;
        if (difficultySelector.Respawns < 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Attack()
    {
        if (!(Swords <= 0))
        {
            Swords--;
            Instantiate(swordProjectilePrefab, firePoint.position, firePoint.rotation);
        }
        Debug.Log("Attack");
    }

    public void PickupSword()
    {
        Swords++;
    }

    public bool UseKey()
    {
        if (Keys > 0)
        {
            Keys--;
            return true;
        }
        return false;
    }

    public void PickupKey()
    {
        Keys++;
    }

    public void AddToScore(int points)
    {
        difficultySelector.Score += points;
    }
}
