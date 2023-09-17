using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Player_Movement movement;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Player_Movement(rb,this);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            movement.OnJump();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(Random.Range(0, 10));
            movement.OnCrouch();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            //gameover
        }
        else
        {
            movement.OnCollisionEnter(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) => movement.OnCollisionExit(collision);

}
