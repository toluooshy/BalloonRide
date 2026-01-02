using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeballController : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Spikeball;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player") {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<BalloonController>().looniemode) {
            Coin.GetComponent<SpriteRenderer>().enabled = true;
            Spikeball.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            Coin.GetComponent<SpriteRenderer>().enabled = false;
            Spikeball.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
