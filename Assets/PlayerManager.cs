using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

  public float maxHealth = 100f;
  public float currentHealth = 100f;

  public enum PlayerState
  {
    Alive,
    Dead
  };

  public PlayerState _state = PlayerState.Alive;

  public void TakeHit(float damage) {
    currentHealth = currentHealth - damage;
    if (currentHealth < 0) {
      _state = PlayerState.Dead;
    }
  }
}
