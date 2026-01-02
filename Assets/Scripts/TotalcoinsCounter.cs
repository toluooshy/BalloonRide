using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalcoinsCounter : MonoBehaviour
{

    public Text TotalcoinsCounterText;

    // Update is called once per frame
    void Update()
    {
        TotalcoinsCounterText.text = PlayerPrefs.GetInt("totalcoins", 0).ToString();  
    }
}
