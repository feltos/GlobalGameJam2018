using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField]
    AudioClip levelSound;
    [SerializeField]
    AudioClip buildingSound;
    [SerializeField]
    AudioClip walkSound;
    [SerializeField]
    AudioClip jumpSound;
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip sawSound;
    [SerializeField]
    AudioClip springSound;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Multiple instances of SoundEffects");
        }
        instance = this;
    }

    void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

    public void LevelSound()
    {
        MakeSound(levelSound);
    }

    public void BuildingSound()
    {
        MakeSound(buildingSound);
    }

    public void WalSound()
    {
        MakeSound(walkSound);
    }

    public void JumpSound()
    {
        MakeSound(jumpSound);
    }

    public void DeathSound()
    {
        MakeSound(deathSound);
    }

    public void SawSound()
    {
        MakeSound(sawSound);
    }

    public void SpringSound()
    {
        MakeSound(springSound);
    }
}
