using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    PlayerCharacter playerCharacter;

    [SerializeField]
    float springForce;
    [SerializeField]
    Animator springAnim;

  

    public void JumpPlayer()
    {
        springAnim.SetInteger("SpringTransition", 1);
        playerCharacter.Body.velocity = new Vector2(playerCharacter.Body.velocity.x, playerCharacter.Body.velocity.y + springForce);
    }
}
