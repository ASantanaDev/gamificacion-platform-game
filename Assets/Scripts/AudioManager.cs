using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Más de un AudioManager en escena");
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproduceSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
