using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Player_Movement movement;
    public Rigidbody2D rb;
    public GameManager gameManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Player_Movement(rb,this);
        GameManager.SubscribeToDelegate(ResetGame);
    }

    private void ResetGame()
    {
        transform.position = new Vector3(-6,-3,0);
    }

    void Update()
    {
        if (!GameManager.Playing())
        {
            return;
        }
        
        if(Input.GetKey(KeyCode.Space)) 
        {
            movement.OnJump();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            movement.OnCrouch();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            gameManager.PlayerDeath();
        }
        else
        {
            movement.OnCollisionEnter(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) => movement.OnCollisionExit(collision);

}
