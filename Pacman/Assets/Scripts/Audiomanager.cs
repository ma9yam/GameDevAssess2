using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [SerializeField] private AudioSource introSound = null;
    [SerializeField] private AudioSource backgroundMusic = null;
    // Start is called before the first frame update
    void Start()
    {
        introSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!introSound.isPlaying && !backgroundMusic.isPlaying)
            backgroundMusic.Play();
    }
}
