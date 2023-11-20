using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioClip audioClip;

    public float health;

    private void Awake()
    {
        health = 3;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        Debug.Log("A base died!");
    }
}
