using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameOverView : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    
    private static GameOverView sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameOverView GetInstance()
    {
        return sharedInstance;
    }

    // Update is called once per frame
    public void UpdateGui()
    {
        if (GameManager.GetInstace().currentGameState == GameState.GameOver)
        {
            coinsLabel.text = GameManager.GetInstace().GetCollectedCoins().ToString();
            scoreText.text = PlayerController.GetInstace().GetDistance().ToString();
        }
    }
}
