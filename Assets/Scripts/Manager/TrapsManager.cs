using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsManager : MonoBehaviour
{
    [SerializeField]
    PlayerCharacter playerCharacter;

    [SerializeField]
    float springForce;
    [SerializeField]
    Animator springAnim;

    float gasPeriod = 0.1f;
    float gasTimer;

    public enum Traps
    {
        PICS,
        SPRING,
        GAS,
        FLAME,
        BANANA_AXE,
        ROTATIVE_SAW
    }
    public Traps traps = Traps.PICS;

    public void CheckTraps()
    {
        switch(traps)
        {
            case Traps.PICS:
                break;

            case Traps.SPRING:
                springAnim.SetInteger("SpringTransition", 1);
                playerCharacter.Body.velocity = new Vector2(playerCharacter.Body.velocity.x, playerCharacter.Body.velocity.y + springForce);
                break;

            case Traps.GAS:
                break;

            case Traps.FLAME:
                break;

            case Traps.BANANA_AXE:
                break;

            case Traps.ROTATIVE_SAW:
                break;
        }
        
           
    }

    void FlameTrap()
    {

    }

    void Banana_AxeTrap()
    {

    }

    void Rotative_SawTrap()
    {

    }
}
