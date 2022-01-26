using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentScript : MonoBehaviour
{
    private AudioSource source;

    public AudioClip footstep1;
    public AudioClip footstep2;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Footstep1()
    {
        source.clip = footstep1;
        source.pitch = Random.Range(0.9f, 1.0f);
        source.Play();
    }

    public void Footstep2()
    {
        source.clip = footstep2;
        source.pitch = Random.Range(0.9f, 1.0f);
        source.Play();
    }
}
