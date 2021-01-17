using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 3.0f;

    private float initialGravity;
    private static PlayerController sharedInstance; //singleton

    private Vector3 initialPosition;
    private Vector2 initialVelocity;
    private const string HIGHEST_SCORE_KEY = "highestScore";

    private void Awake()
    {
        sharedInstance = this; //singleton
        rigidBody = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialVelocity = rigidBody.velocity;
        animator.SetBool("isAlive", true);
        initialGravity = rigidBody.gravityScale;

    }

    public static PlayerController GetInstace() //singleton
    {
        return sharedInstance;
    }
    
    // Start is called for GameManager
    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        transform.position = initialPosition;
        rigidBody.velocity = initialVelocity;
        rigidBody.gravityScale = initialGravity;
        // GameManager.GetInstace();
    }

    private void FixedUpdate()
    {
        GameState currState = GameManager.GetInstace().currentGameState;
        if (currState == GameState.InGame)
        {
            if (rigidBody.velocity.x < runSpeed)
            {
                rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            }
        }
        
        // throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        bool cantJump = GameManager.GetInstace().currentGameState == GameState.InGame;
        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded", isOnTheGround);
        if (cantJump && (Input.GetMouseButtonDown(0) 
             || Input.GetKeyDown(KeyCode.Space)
             || Input.GetKeyDown(KeyCode.W)
             ) && IsOnTheGround()
            )
        {
            // print("Left mouse's button clicked");            
            Jump();
        }
    }
    void Jump()
    {
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }

    private bool IsOnTheGround()
    {
        // print("mask=" + groundLayerMask);
        return Physics2D.Raycast(transform.position, Vector2.down,
            1.0f, groundLayerMask.value);
    }

    public void KillPlayer()
    {
        animator.SetBool("isAlive", false);
        int highestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
        int currentScore = GetDistance();
        if (currentScore > highestScore)
        {
            PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, currentScore);
        }

        rigidBody.gravityScale = 0f;
        rigidBody.velocity = Vector2.zero;
        GameManager.GetInstace().GameOver();

    }

    public int GetDistance()
    {
        var distance = (int) Vector2.Distance(initialPosition, transform.position);
        print("Distance: " + distance);
        return distance;
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
    }
}
