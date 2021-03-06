﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    GameObject groundCheck;
    bool isGrounded;
    [SerializeField]
    BoxCollider2D springCollider;
    [SerializeField]
    Spring spring;
    float springForce = 13;

    GameManager gameManager;

    public Rigidbody2D Body
    {
        get
        {
            return body;
        }

        set
        {
            body = value;
        }
    }

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(speed * horizontal, body.velocity.y);
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) && isGrounded)
        {
            body.velocity = body.velocity + Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Traps"))
        {
            gameManager.PlayerDie();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spring"))
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y + springForce);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            gameManager.PlayerWin();
        }
    }
}
