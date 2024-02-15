using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class UIText : MonoBehaviour
{
    public List<GameObject> hearts;
    public TMP_Text score;
    public TMP_Text time;
    public TMP_Text swords;
    public TMP_Text keys;
    public TMP_Text respawns;

    public PlayerStats playerStats;
    public Timer timer;

    private DifficultySelector difficultySelector; // Reference to DifficultySelector script

    // Start is called before the first frame update
    void Start()
    {
        difficultySelector = FindObjectOfType<DifficultySelector>();
        hearts = GameObject.FindGameObjectsWithTag("Heart").ToList();       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        score.text = "Score: " + playerStats.Score;
        time.text = "Time: " + (int)timer.time;
        swords.text = "Swords: " + playerStats.Swords;
        keys.text = "Keys: " + playerStats.Keys;
        respawns.text = "Respawns: " + difficultySelector.Respawns;
        if (hearts.ToArray().Length > playerStats.HP)
        {
            hearts[0].SetActive(false);
            hearts.RemoveAt(0);
        }
    }
}
