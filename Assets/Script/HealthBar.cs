using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    List<GameObject> allHearts;

    // Start is called before the first frame update
    void Start()
    {
        //Finds all hearts in the scene
        allHearts = GameObject.FindGameObjectsWithTag("Heart").ToList();
    }
    //Removes a heart
    void UpdateHearts()
    {
        Destroy(allHearts[0]);
        allHearts.RemoveAt(0);
    }
}
