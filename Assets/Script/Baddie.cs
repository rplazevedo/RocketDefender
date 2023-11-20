using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Baddie : MonoBehaviour
{
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.back * 5f); // rotate around z-axis i.e. perpendicular to the camera
    }

    public void AssignTarget(Base target, float speed)
    {
        var targetPos = target.transform.position;
        var baddiePos = transform.position;
        var directionToTarget = (target.transform.position - transform.position).normalized;
        body.AddForce(directionToTarget * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            collision.gameObject.GetComponent<Base>().Damage(1);
            Debug.Log("Base hit!");
        }

        if (!collision.gameObject.CompareTag("Baddie"))
        {
            Destroy(this.gameObject);
        }
        
    }
}

