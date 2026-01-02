using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UltrabarController : MonoBehaviour
{
    public GameObject Ultrabar;
    public GameObject UltrabarBar;
    public GameObject Player;
    public float barheight = 1000;

    private float DecrementTime;

    // Start is called before the first frame update
    void Start()
    {
        Ultrabar.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<BalloonController>().ultramode) {
            Ultrabar.GetComponent<Canvas>().enabled = true;
            if (Time.time > DecrementTime + .049f) {
                barheight -= 10;
                DecrementTime = Time.time + .049f;
            }
            UltrabarBar.GetComponent<RectTransform>().offsetMax = new Vector2(7.5f, -(1000 - barheight) -7.5f);
        } else {
            Ultrabar.GetComponent<Canvas>().enabled = false;
            barheight = 1000;
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(.1f);
    }
}
