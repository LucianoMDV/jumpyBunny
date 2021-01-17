using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private bool isCollected = false;

    void HideConin()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.enabled = false;
        }
        var collider = GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
    void CollectCoin()
    {
        isCollected = true;
        HideConin();
        GameManager gm = GameManager.GetInstace();
        gm.CollectCoins();
        print("Coins collected: " + gm.GetCollectedCoins());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
        // throw new NotImplementedException();
    }
}
