using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource myAudio;
    public List<AudioClip> footsteps;
    
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    
    public void Footstep()
    {
        myAudio.clip = footsteps[Random.Range(0, footsteps.Count)];
        myAudio.Play();
    }
}
