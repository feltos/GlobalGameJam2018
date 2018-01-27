using System.Collections;
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
    float springForce;
    [SerializeField]
    Animator springAnim;
    [SerializeField]
    BoxCollider2D springCollider;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(speed * horizontal, body.velocity.y);
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.velocity = body.velocity + Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Traps"))
        {
            //call other scripts TrapsManager
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Spring"))
        {
            springAnim.SetInteger("SpringTransition", 1);
            body.velocity = new Vector2(body.velocity.x, body.velocity.y + springForce);
           
        }
    }
}
