using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HealthbarController : MonoBehaviour
{
    public GameObject Healthbar;
    public GameObject HealthbarBar;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Healthbar.GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthbarBar.GetComponent<RectTransform>().offsetMax = new Vector2(7.5f, -(100 - Player.GetComponent<BalloonController>().health) * 10 -7.5f);
    }
}
