using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public int initialHP;
    public int initialSwords;
    public int Respawns;
    public int SelectedDiff;

    // Ensure the object persists between scenes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Easy()
    {
        SelectedDiff = 0;
        ApplyDifficultySettings();
    }
    public void Medium()
    {
        SelectedDiff = 1;
        ApplyDifficultySettings();
    }
    public void Hard()
    {
        SelectedDiff = 2;
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        // Apply initial stats to the player based on the selected difficulty
        switch (SelectedDiff)
        {
            case 0: // Easy
                initialHP = 3;
                initialSwords = 3;
                break;
            case 1: // Medium
                initialHP = 2;
                initialSwords = 2;
                break;
            case 2: // Hard
                initialHP = 1;
                initialSwords = 1;
                break;
            default:
                Debug.LogWarning("Invalid difficulty selected.");
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
