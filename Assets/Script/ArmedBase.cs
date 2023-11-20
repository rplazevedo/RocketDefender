using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedBase : Base
{
    [SerializeField]
    private Rocket rocket;
    [SerializeField]
    private float rocketSpeed = 3f;

    [SerializeField]
    private float fireRate;
    private float shootTime;

    [SerializeField]
    private Game game;

    private float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot())
        {
            Fire();
        }
    }

    void Fire()
    {
        speedMultiplier = 1f + (game.roundNumber * 0.2f);
        shootTime = Time.time;
        Rocket rocketInstance = Instantiate(rocket);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rocketInstance.Launch(direction, speedMultiplier * rocketSpeed);
    }


    public bool CanShoot()
    {
        return  Time.time >= shootTime + fireRate;
    }
}
