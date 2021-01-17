using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;

    private static ViewInGame sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static ViewInGame GetInstance()
    {
        return sharedInstance;
    }

    private void Start()
    {
        // highestScoreText.text = PlayerController.GetInstace().GetMaxScore().ToString();
    }

    public void ShowHighestScore()
    {
        highestScoreText.text = PlayerController.GetInstace().GetMaxScore().ToString();
    }
    // Update is called once per frame
    void Update()
    {
        // if (GameManager.GetInstace().currentGameState == GameState.Menu)
        // {
        //     showHighestScore();
        // }

        if (GameManager.GetInstace().currentGameState == GameState.InGame)
        {
            scoreText.text = PlayerController.GetInstace().GetDistance().ToString();
        }
    }

    public void UpdateCoins()
    {
        coinsLabel.text = GameManager.GetInstace().GetCollectedCoins().ToString();
    }
}
