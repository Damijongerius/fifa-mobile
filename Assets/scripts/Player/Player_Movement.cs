using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement
{
    private Player player;
    private Rigidbody2D rb;
    private bool grounded;
    private bool dropping;
    public Player_Movement(Rigidbody2D rb, Player player)
    {
        this.rb = rb;
        this.player = player;
    }

    public void OnJump()
    {
        if (grounded)
        {
            rb.velocity += new Vector2(0, 10);
            grounded = false;
            player.StartCoroutine(ChangeBooleanWithDelay());
        }
    }

    public void OnCrouch()
    { 
        if(!dropping)
        {
            if(rb.velocity.y > 0.1f) rb.velocity = Vector2.zero;
            rb.velocity = Vector2.down * 5 + rb.velocity;
            dropping = true;
        }
    }

    public void OnCollisionEnter(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            grounded = true;
        }
    }

    public void OnCollisionExit(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            grounded = false;
        }
    }

    private IEnumerator ChangeBooleanWithDelay()
    {
        // Wait for 0.05 seconds
        yield return new WaitForSeconds(0.05f);

        dropping = false;
    }
}
