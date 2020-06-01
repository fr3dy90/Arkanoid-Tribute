using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data")]
public class GameData : ScriptableObject
{
   [Header("Player Data")]
   public int playerLives;
   public float normalSpeed;
   public float maxSpeed;
}
