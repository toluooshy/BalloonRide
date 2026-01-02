using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject Jukebox;
    public AudioSource src;
    public AudioClip song1;

    public static MusicManager instance;

    private bool playingmusic = true;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(Jukebox);
            DontDestroyOnLoad(src);
        } else {
            Destroy(Jukebox);
            Destroy(src);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("activemusic", 1) == 1) {
            src.clip = song1;
            src.loop = true;
            src.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("activemusic", 1) == 1) {
            playingmusic = false;
        }

        if (PlayerPrefs.GetInt("activemusic", 1) == 0 && !playingmusic) {
            src.clip = song1;
            src.loop = true;
            src.Play();
        }
    }
}
