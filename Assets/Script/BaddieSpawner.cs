using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaddieSpawner : MonoBehaviour
{
    [SerializeField]
    private Baddie baddieToSpawn;

    [SerializeField]
    private float spawnRegionWidth;

    [SerializeField]
    private Bases bases;

    public IEnumerator StartSpawning()
    {
        // spawn enemy
        SpawnBaddie();
        // wait a couple of seconds, random
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        // start coroutine again
        StartCoroutine(StartSpawning());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private Vector3 GetRandomPosition()
    {
        float randomXPosition = Random.Range(-spawnRegionWidth, spawnRegionWidth);
        return new Vector3(randomXPosition, transform.position.y, transform.position.z);
    }

    void SpawnBaddie()
    {
        Baddie baddieInstance = Instantiate(baddieToSpawn, GetRandomPosition(), Quaternion.identity);
        baddieInstance.AssignTarget(bases.GetRandomBase(), Random.Range(1f, 3f));
    }
}
