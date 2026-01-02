using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreCounter : MonoBehaviour
{

    public Text HighscoreCounterText;

    // Update is called once per frame
    void Update()
    {
        HighscoreCounterText.text = PlayerPrefs.GetInt("highscore", 0).ToString();  
    }
}
