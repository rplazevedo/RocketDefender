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

    public void Launch(Vector2 direction, float speed)
    {

        body.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 5f); // rotate around z-axis i.e. perpendicular to the camera
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioClipArray[1]);
        Destroy(this.gameObject, .33f); // delay mainly to let the audioclip finish
    }
}
