using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;     // Where the ball comes out 
    public float fireRate = 2f;

    private float timer;
    private Transform playerHead;

    void Start()
    {
        playerHead = Camera.main.transform;
    }

    void Update()
    {
        // 1. Always look at the player
        transform.LookAt(new Vector3(playerHead.position.x, transform.position.y, playerHead.position.z));

        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Create the ball at the firePoint's position
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}