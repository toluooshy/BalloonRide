using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject infoDisplay;

    public GameObject settingsDisplay;

    public GameObject musicButton;

    public GameObject sfxButton;

    private bool activemusic;

    private bool activesfx;

    // Start is called before the first frame update
    void Start()
    {    
        activemusic = PlayerPrefs.GetInt("activemusic", 1) == 1;
        activesfx = PlayerPrefs.GetInt("activesfx", 1) == 1;

        infoDisplay.GetComponent<Canvas>().enabled = false;
        settingsDisplay.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (activemusic) {
            PlayerPrefs.SetInt("activemusic", 1);
            musicButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Buttons/accept");
        } else {
            PlayerPrefs.SetInt("activemusic", 0);
            musicButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Buttons/cancel");
        }

        if (activesfx) {
            PlayerPrefs.SetInt("activesfx", 1);
            sfxButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Buttons/accept"); 
        } else {
            PlayerPrefs.SetInt("activesfx", 0);
            sfxButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Buttons/cancel"); 
        }
    }

    public void ToggleInfoDisplay(bool state) {
        infoDisplay.GetComponent<Canvas>().enabled = state;
    }

    public void ToggleSettingsDisplay(bool state) {
        settingsDisplay.GetComponent<Canvas>().enabled = state;
    }

    public void ToggleMusic() {
        activemusic = !activemusic;

    }

    public void ToggleSFX() {
        activesfx = !activesfx;
        
    }
}
