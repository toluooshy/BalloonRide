using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public Text ScoreCounterText;
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
        if (Player.GetComponent<BalloonController>().ingame) {
            if (Time.time > IncrementTime) {
                IncrementTime = Time.time + TimeBetweenIncrement;
                ScoreCounterText.text = "score " +  Player.GetComponent<BalloonController>().score.ToString();
                Player.GetComponent<BalloonController>().score += 1;
            }   
        } else {
            ScoreCounterText.text = Player.GetComponent<BalloonController>().score.ToString();
        }
    }
}
