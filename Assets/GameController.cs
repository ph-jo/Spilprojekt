﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public Text coinsText;
    public GameObject gameOver;
    public GameObject lostTheGame;
    public int coins = 0;
    public bool gameLost = false;
    public GameObject player;
    public GameObject gameWon;
    private LifeCount lives;
    public Text lifeText;
    private bool dead;
    private int saveID;
   

    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
            lives = FindObjectOfType<LifeCount>();
            if(lives.getLives() == 1)
            {
                lifeText.text = lives.getLives() + " Death";
            }
            else
            {
                lifeText.text = lives.getLives() + " Deaths";

            }
            dead = false;   
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        
	}




    // Update is called once per frame
    void Update () {
		
        if(gameLost && Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

           // EnemyScript enemies = FindObjectOfType<EnemyScript>();

           // Application.LoadLevel(Application.loadedLevel);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            youDiedLOL();
        }
        //Commented out - Changed lifecount to deathcount, with the introduction of checkpoints, the player now has unlimited lives.
        //else if(outOfLives && Input.GetKeyDown(KeyCode.R))
        //{
            
        //    SceneManager.LoadScene(1);
        //    lives.setLives(3);
        //}
	}
    public void gameCompleted()
    {
        gameWon.SetActive(true);
        player.SetActive(false);
    }
    public void youDiedLOL()

    {
      
        if (dead) return;
        dead = true;
        lives.playerDeath();
        //Commented out - see above
        //if (lives.getLives() == 0)
        //{
        //    lostTheGame.SetActive(true);
        //    outOfLives = true;
        //}else
        //{
            gameOver.SetActive(true);
            gameLost = true;
        //}
        player.SetActive(false);

    }

    public void gameCompletelyOver()
    {
        
    }

    public void pickupCoin()
    {
        coins++;
        coinsText.text = coins + "";
    }

   


}
