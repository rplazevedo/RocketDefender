using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D body;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClipArray;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClipArray[0]);
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        
    }
}
