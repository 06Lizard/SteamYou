using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    public PlayerStats playerStats; // Reference to the PlayerStats script
    private DifficultySelector difficultySelector; // Reference to DifficultySelector script

    public TextMeshProUGUI HP_textMeshProComponent;
    public TextMeshProUGUI Score_textMeshProComponent;
    public TextMeshProUGUI Swords_textMeshProComponent;
    public TextMeshProUGUI Keys_textMeshProComponent;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNumberText();
    }

    private void FixedUpdate()
    {
        UpdateNumberText();
    }

    // Update is called once per frame
    void UpdateNumberText()
    {       
        HP_textMeshProComponent.text = playerStats.HP.ToString();
        Score_textMeshProComponent.text = difficultySelector.Score.ToString();
        Swords_textMeshProComponent.text = playerStats.Swords.ToString();
        Keys_textMeshProComponent.text = playerStats.Keys.ToString();
    }
}
