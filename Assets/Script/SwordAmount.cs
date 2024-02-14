using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwordAmount : MonoBehaviour
{
    public TMP_Text amountText;
    int swordAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        amountText.text = "Swords: " + swordAmount.ToString();
    }

    //Updates the sword amount with the change
    void UpdateSwordAmount(int change)
    {
        amountText.text = "Swords: " + (swordAmount + change).ToString();
    }
}
