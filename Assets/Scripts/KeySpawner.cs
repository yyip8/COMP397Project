using System.Collections;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject KeyPreFab;
    public int numberOfKeysToSpawn = 50;
    public float spawnInterval = 3.0f;
    public float spawnIntervalMax = 18.0f;
    public string playerTag = "Player";
    public float spawnDistance = 2f;
    public float spawnDistanceMax = 20f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure the player has the correct tag assigned.");
            return;
        }

        StartCoroutine(KeySpawnRoutine());
    }

    private IEnumerator KeySpawnRoutine()
    {
        for (int i = 0; i < numberOfKeysToSpawn; i++)
        {
            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 playerForward = player.transform.forward;
                Vector3 spawnPosition = playerPosition + playerForward * Random.Range(spawnDistance, spawnDistanceMax);
                Instantiate(KeyPreFab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(Random.Range(spawnInterval,spawnIntervalMax));
        }
    }
}
