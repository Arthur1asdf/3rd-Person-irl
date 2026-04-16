using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int maxEnemy = 6;
    public float spawnInterval = 2f;
    public float spawnRadius = 3f;

    private List<GameObject> spawnedBalls = new List<GameObject>();
    private float timer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float heightOffset = 0.3f;
    [SerializeField] private float forwardDistance = 3f;
    [SerializeField] private float sideRange = 1.5f;
    [SerializeField] private float minSpawnDistance = 1.2f;
    [SerializeField] private int maxSpawnAttempts = 10;

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
        if (spawnedBalls.Count >= maxEnemy) return;
        if (ballPrefab == null || playerTransform == null) return;

        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float sideOffset = Random.Range(-sideRange, sideRange);

            Vector3 spawnPos =
                playerTransform.position
                + playerTransform.forward * forwardDistance
                + playerTransform.right * sideOffset;

            spawnPos.y = playerTransform.position.y - heightOffset;

            bool tooClose = false;

            foreach (GameObject enemy in spawnedBalls)
            {
                if (enemy == null) continue;

                float distance = Vector3.Distance(spawnPos, enemy.transform.position);

                if (distance < minSpawnDistance)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
            {
                GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
                spawnedBalls.Add(newBall);
                return;
            }
        }

        Debug.Log("Could not find a non-overlapping spawn position.");
    }
}