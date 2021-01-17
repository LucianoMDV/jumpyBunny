using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D element)
  {
    if (element.CompareTag("Player"))
    {
      print("Bunny has benn eliminated");
      PlayerController.GetInstace().KillPlayer();
    }
    // throw new NotImplementedException();
  }
}
