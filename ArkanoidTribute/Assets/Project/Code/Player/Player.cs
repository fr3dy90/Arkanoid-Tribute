using System;
using UnityEngine;
    
public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private Camera cam;
    
    public float normalSpeed;
    public float maxSpeed;
    private float speed;

    private Ball ball;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        speed = normalSpeed;
    }

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && transform.position.x + (sr.size.x) / 2 > cam.orthographicSize / 2)
        {
            return;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && transform.position.x - (sr.size.x) / 2 < (cam.orthographicSize / 2)*-1)
        {
            return;
        }
        
        transform.Translate((Vector3.right * (speed * Time.deltaTime)) * Input.GetAxisRaw("Horizontal"));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ball")
        {
            ball.GetDirFromPlayer((int)Input.GetAxisRaw("Horizontal"));
        }
    }
}