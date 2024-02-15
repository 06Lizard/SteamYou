using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    private int initialHP;
    private int initialSwords;
    public int SelectedDiff;

    enum Diff
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }

    private void Start()
    {
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        // Find the player GameObject in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                // Apply initial stats to the player
                Diff selectedDifficulty = (Diff)SelectedDiff;

                switch (selectedDifficulty)
                {
                    case Diff.Easy:
                        playerStats.HP = 3;
                        //respawn = 3
                        playerStats.Swords = 3;
                        break;
                    case Diff.Medium:
                        playerStats.HP = 2;
                        //respawn = 3
                        playerStats.Swords = 2;
                        break;
                    case Diff.Hard:
                        playerStats.HP = 1;
                        //respawn = 0
                        playerStats.Swords = 1;
                        break;
                    default:
                        //Return to menue
                        break;
                }
                // Add logic for respawns if needed
            }
            else
            {
                Debug.LogError("PlayerStats component not found on player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found in the scene.");
        }
    }
}
