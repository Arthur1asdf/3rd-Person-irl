using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int maxBalls = 6;
    public float spawnInterval = 2f;
    public float spawnRadius = 3f;

    private List<GameObject> spawnedBalls = new List<GameObject>();
    private float timer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float heightOffset = 0.3f;
    [SerializeField] private float forwardDistance = 3f;
    [SerializeField] private float sideRange = 1.5f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            TrySpawnBall();
        }

        // Clean up the list if any balls were destroyed
        spawnedBalls.RemoveAll(item => item == null);
    }

    void TrySpawnBall()
    {
        if (spawnedBalls.Count >= maxBalls) return;
        if (ballPrefab == null || playerTransform == null) return;

        // Generate a random position in a circle around the player
        //Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        //Vector3 spawnPos = playerTransform.position + new Vector3(randomCircle.x, 0, randomCircle.y);
        
        float forwardDistance = spawnRadius;
        float sideOffset = Random.Range(-sideRange, sideRange);

        Vector3 spawnPos =
            playerTransform.position
            + playerTransform.forward * forwardDistance
            + playerTransform.right * sideOffset;

        spawnPos.y = playerTransform.position.y - heightOffset;

        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        spawnedBalls.Add(newBall);
    }
}