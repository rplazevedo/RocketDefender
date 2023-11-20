using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    public float health;

    private void Awake()
    {
        health = 3;
        audioSource = GetComponent<AudioSource>();
    }

    public void Damage(int amount)
    { 
        health -= amount;
        audioSource.PlayOneShot(audioClip);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("A base died!");
    }
}
