using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileRank rank;
    public int touchesUntilDestroy;
    public int scoreByTouch;
    public int scoreByDestroy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ball")
        {
            touchesUntilDestroy--;
            if (touchesUntilDestroy <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

public enum TileRank
{
    S_Rank,
    A_Rank,
    B_Rank,
    C_Rank,
    D_Rank,
    E_Rank
}