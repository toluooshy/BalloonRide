using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameoverDisplay;
    public GameObject IngameDisplay;

    // Start is called before the first frame update
    void Start()
    {
        IngameDisplay.GetComponent<Canvas>().enabled = true;
        GameoverDisplay.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<BalloonController>().ingame) {
            IngameDisplay.GetComponent<Canvas>().enabled = true;
            GameoverDisplay.GetComponent<Canvas>().enabled = false;
        } else {
            IngameDisplay.GetComponent<Canvas>().enabled = false;
            GameoverDisplay.GetComponent<Canvas>().enabled = true;
        }
    }
}
