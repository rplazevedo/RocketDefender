using System.Collections;
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

    [SerializeField]
    private Game game;

    private float speedMultiplier;

    public IEnumerator StartSpawning()
    {
        // spawn enemy
        SpawnBaddie();
        // wait a couple of seconds, random
        yield return new WaitForSeconds(Random.Range(1f, 3f - game.roundNumber * 0.2f));
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
        speedMultiplier = 1f + (game.roundNumber * 0.2f);
        Baddie baddieInstance = Instantiate(baddieToSpawn, GetRandomPosition(), Quaternion.identity);
        baddieInstance.AssignTarget(bases.GetRandomBase(), speedMultiplier * Random.Range(1f, 3f));
    }
}
