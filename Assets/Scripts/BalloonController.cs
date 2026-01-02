using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BalloonController : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float jumpAmount = 5;

    public int score = 0;
    public int coins = 0;
    public int health = 100;
    public bool looniemode = false;
    public int loonieduration = 10;
    public int loonietimestamp = 0;
    public bool ultramode = false;
    public int ultraduration = 10;
    public int ultratimestamp = 0;
    public int damagetimestamp = 0;
    public int healedtimestamp = 0;
    public bool gameover = false;
    public bool ingame = true;
    private bool isdamaged = false;
    private bool ishealed = false;

    bool initialgameoverload = true;

    public AudioSource src;

    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5;

    Animator animator;

    private bool activemusic;

    private bool activesfx;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/balloon_0") as RuntimeAnimatorController;

        activemusic = PlayerPrefs.GetInt("activemusic", 1) == 1;
        activesfx = PlayerPrefs.GetInt("activesfx", 1) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Assets/Animations/balloonjet_0") as RuntimeAnimatorController;
        
        if (transform.position.y >= 4) {
            transform.position = new Vector3(transform.position.x, 4, 0);
        }

        if (!gameover) {
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && transform.position.y < 4) {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }
        }

        if (looniemode) {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            int loonietimediff = (int)t.TotalSeconds;

            if (loonietimediff - loonietimestamp >= loonieduration) {
                looniemode = false;
            }
        }

        if (ultramode) {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            int ultratimediff = (int)t.TotalSeconds;

            if (ultratimediff - ultratimestamp >= ultraduration) {
                ultramode = false;
                animator.runtimeAnimatorController = Resources.Load("Animations/balloon_0") as RuntimeAnimatorController;
            }
        }

        if (isdamaged) {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            int damagediff = (int)t.TotalSeconds;

            if (damagediff - damagetimestamp >= 1) {
                isdamaged = false;
                animator.runtimeAnimatorController = Resources.Load("Animations/balloon_0") as RuntimeAnimatorController;
            }
        }

        if (ishealed) {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            int healedtimediff = (int)t.TotalSeconds;

            if (healedtimediff - healedtimestamp >= 1) {
                ishealed = false;
                animator.runtimeAnimatorController = Resources.Load("Animations/balloon_0") as RuntimeAnimatorController;
            }
        }

        if (health <= 0) {
            gameover = true;
        }

        if (transform.position.y < -7.5) {
            ingame = false;
            if(initialgameoverload) {
                int loadedHighscore = PlayerPrefs.GetInt("highscore", 0);
                if (score > loadedHighscore) {
                    PlayerPrefs.SetInt("highscore", score);
                }

                int loadedCoins = PlayerPrefs.GetInt("totalcoins", 0);
                PlayerPrefs.SetInt("totalcoins", coins+loadedCoins);
                initialgameoverload = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (Player.GetComponent<BalloonController>().ingame) {
            if(collision.tag == "Coin") {
                src.clip = sfx1;
                if(activesfx) {
                    src.Play();
                }
                if (ultramode) {
                    coins += 2;
                    score += 10;
                } else {
                    coins += 1;
                    score += 5;
                }
            }
            if(collision.tag == "Loonie") {
                src.clip = sfx2;
                if(activesfx) {
                    src.Play();
                }
                looniemode = true;
                TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
                loonietimestamp = (int)t.TotalSeconds;

                if (ultramode) {
                    coins += 200;
                    score += 1000;
                } else {
                    coins += 100;
                    score += 500;
                }
            }
            if(collision.tag == "Medkit") {
                src.clip = sfx3;
                if(activesfx) {
                    src.Play();
                }
                health += 20;
                if (health >= 100){
                    health = 100;
                }
                ishealed = true;
                TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
                healedtimestamp = (int)t.TotalSeconds;
                animator.runtimeAnimatorController = Resources.Load("Animations/balloonhealed_0") as RuntimeAnimatorController;
            }
            if(collision.tag == "Spikeball") {
                if (ultramode || looniemode) {
                    health -= 0;
                    if (looniemode) {
                        src.clip = sfx1;
                        if(activesfx) {
                            src.Play();
                        }
                    }
                } else {
                    src.clip = sfx4;
                    if(activesfx) {
                        src.Play();
                    }
                    health -= 10;
                    isdamaged = true;
                    TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
                    damagetimestamp = (int)t.TotalSeconds;
                    animator.runtimeAnimatorController = Resources.Load("Animations/balloondamage_0") as RuntimeAnimatorController;
                }
            }
            if(collision.tag == "Ultrajet") {
                src.clip = sfx5;
                if(activesfx) {
                    src.Play();
                }
                ultramode = true;
                TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
                ultratimestamp = (int)t.TotalSeconds;
                animator.runtimeAnimatorController = Resources.Load("Animations/balloonjet_0") as RuntimeAnimatorController;
            }
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
    }
}
