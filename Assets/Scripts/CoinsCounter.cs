using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{

    public Text CoinsCounterText;
    public float TimeBetweenIncrement;
    private float IncrementTime;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CoinsCounterText.text = "coins " +  Player.GetComponent<BalloonController>().coins.ToString();  
    }
}
