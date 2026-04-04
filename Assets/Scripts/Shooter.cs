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
            Vector3 fireOffset = new Vector3(0.23f, 0.04f, -.75f); //numbers may need to be changed later
            Vector3 spawnPosition = firePoint.position + fireOffset;

            Instantiate(bulletPrefab, spawnPosition, firePoint.rotation);
        }
    }
}