using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] public int SelectedDiff;
    public PlayerStats playerStats;

    enum Diff
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }

    private void Start()
    {
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
    }
}
