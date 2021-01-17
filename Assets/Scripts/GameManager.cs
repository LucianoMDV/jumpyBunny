using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 1) Menu
 * 2) InGame
 * 3) GameOver
 * 4) Pause
 */

enum DaysOfTheWeek
{
    Monday = 1,
    Tuesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum GameState
{
    Menu, 
    InGame, 
    GameOver,
    Resume
}

public class GameManager : MonoBehaviour
{
    // private DaysOfTheWeek currentDay = DaysOfTheWeek.Sunday;
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance; //singleton
    public Canvas mainMenu;
    public Canvas gameMenu;
    public Canvas gameOverMenu;
    
    private void Awake()
    {
        sharedInstance = this; //singleton
    }

    public static GameManager GetInstace() //singleton
    {
        return sharedInstance;
    }
    public void StartGame()
    {
        // print("Today is: " + (int) currentDay);
        LevelGenerator.sharedInstance.createInitialBlock();
        PlayerController.GetInstace().StartGame();
        ChangeGameState(GameState.InGame);
    }
    // Start our game
   public void Start()
    {
        // StartGame();
        currentGameState = GameState.Menu;
        mainMenu.enabled = true;
        gameMenu.enabled = false;
        gameOverMenu.enabled = false;
    }

   // Called when player dies
    public void Update()
    {
        if (currentGameState != GameState.InGame && Input.GetButtonDown("S key"))
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }
    }
    
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        // LevelGenerator.sharedInstance.RemoveOldBlock();
        ChangeGameState(GameState.GameOver);
    }
    
    //Called when the player decide to quick the game
    //and go to the menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Menu:
                //Let's load Mainmeny Scene
                mainMenu.enabled = true;
                gameMenu.enabled = false;
                gameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                //Unity Scene must show the Real game
                mainMenu.enabled = false;
                gameMenu.enabled = true;
                gameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                //Let's load end of the game scene
                mainMenu.enabled = false;
                gameMenu.enabled = false;
                gameOverMenu.enabled = true;
                break;
            default:
                newGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
