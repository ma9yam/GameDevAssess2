using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip movingSound;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        playMovingSound();
    }

    void playMovingSound()
    {
        audio.PlayOneShot(movingSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
