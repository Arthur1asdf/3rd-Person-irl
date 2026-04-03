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
    private Transform playerTransform;

    void Start()
    {
        // We find the CenterEyeAnchor automatically
        Camera cam = Camera.main;
        if (cam != null) playerTransform = cam.transform;
    }

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
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = playerTransform.position + new Vector3(randomCircle.x, 0, randomCircle.y);

        // Set height to roughly chest level (1.2 meters)
        float randomHeight = Random.Range(0.5f, 1.5f);
        spawnPos.y = randomHeight;

        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        spawnedBalls.Add(newBall);
    }
}