using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsManager : MonoBehaviour
{
    public enum Traps
    {
        PICS,
        SPRING,
        GAS,
        FLAME,
        BANANA_AXE,
        ROTATIVE_BOULE
    }
    public Traps traps = Traps.PICS;

    private void Update()
    {
        CheckTraps(); 
    }
    public void CheckTraps()
    {
        switch(traps)
        {
            case Traps.SPRING:
               
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
