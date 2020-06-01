using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer sr;
    private Camera cam;
    private float dirX = .8f;
    private float dirY = 1;
    private Vector2 Vmov;

    public float ballSpeed;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        BallMovement();
    }

    void BallMovement()
    {
        if (transform.position.x + (sr.size.x / 2) > cam.orthographicSize / 2)
        {
            dirX = -dirX;
        }
        else if(transform.position.x - (sr.size.x/2) < (cam.orthographicSize/2)*-1)
        {
            dirX = math.abs(dirX);
        }

        if (transform.position.y + (sr.size.y / 2) > (cam.orthographicSize * 2))
        {
            dirY = -dirY;
        }

        Vmov.x = dirX;
        Vmov.y = dirY;
        transform.Translate(Vmov*(Time.deltaTime*ballSpeed));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Brick")
        {
            /*Debug.Log(other.contacts[0].normal);
            Debug.Break();
            
            if (other.contacts[0].point.x < transform.position.x)
            {
                dirX = math.abs(dirX);
            }
            else if (other.contacts[0].point.x > transform.position.x)
            {
                dirX = -dirX;
            }
            
            if (other.contacts[0].point.y < transform.position.y)
            {
                dirY = math.abs(dirY);
            }
            else if (other.contacts[0].point.y > transform.position.y)
            {
                dirY = -dirY;
            }
            */

            if (other.contacts[0].normal.x != 0)
            {
                dirX = other.contacts[0].normal.x;
            }

            if (other.contacts[0].normal.y != 0)
            {
                dirY = other.contacts[0].normal.y;
            }
        }
    }

    public void GetDirFromPlayer(int x)
    {
        if (x != 0)
        {
            dirX = x;
        }
        dirY = math.abs(dirY);
    }
}
