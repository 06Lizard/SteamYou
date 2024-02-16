using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public int initialHP;
    public int initialSwords;
    public int Respawns;
    public int SelectedDiff = 0;
    public int Score = 0;
    private int ScoreSave = 0;
    private bool CanGoBack = false;
    private int Timer = 0;

    // Ensure the object persists between scenes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Easy()
    {
        SelectedDiff = 1;
        ApplyDifficultySettings();
    }
    public void Medium()
    {
        SelectedDiff = 2;
        ApplyDifficultySettings();
    }
    public void Hard()
    {
        SelectedDiff = 3;
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        // Apply initial stats to the player based on the selected difficulty
        switch (SelectedDiff)
        {
            case 1: // Easy
                initialHP = 3;
                initialSwords = 3;
                Respawns = 2;
                break;
            case 2: // Medium
                initialHP = 2;
                initialSwords = 2;
                Respawns = 1;

                break;
            case 3: // Hard
                initialHP = 1;
                initialSwords = 1;
                Respawns = 0;
                break;
            default:
                Debug.LogWarning("Invalid difficulty selected.");
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveScore()
    {
        ScoreSave = Score;
    }

    public void LoadScore()
    {
        Score = ScoreSave;
    }

    private void Update()
    {
        if (Input.anyKeyDown && CanGoBack)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Increment the timer every fixed update
            Timer++;

            // Check if 180 fixed updates have passed (assuming FixedUpdate is called every 0.02s)
            if (Timer >= 180)
            {
                CanGoBack = true;
            }
        }
    }
}
