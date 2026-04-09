using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private float timer;
    private Transform targetBody; // Changed from playerHead

    void Start()
    {
        FindTargetBody();
    }

    void FindTargetBody()
    {
        // Matches the logic your bullet uses to find the player
        GameObject body = GameObject.Find("BodyCollider");
        if (body != null)
        {
            targetBody = body.transform;
        }
        else
        {
            Debug.LogWarning("EnemyShooter: Could not find BodyCollider in the scene!");
        }
    }

    void Update()
    {
        if (targetBody != null)
        {
            // Calculate position to look at (Cowboy's Y height to prevent tilting)
            Vector3 targetPosition = new Vector3(targetBody.position.x, transform.position.y, targetBody.position.z);

            // Rotate the Cowboy to face the BodyCollider
            transform.LookAt(targetPosition);
        }
        else
        {
            // Retry finding the body if it was missing
            FindTargetBody();
        }

        // Shooting logic
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}