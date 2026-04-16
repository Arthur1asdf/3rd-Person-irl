using UnityEngine;

public class ControllerProjectileCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // check if the projectile is over a cowboy
        if (other.CompareTag("AREnemy"))
        {
            // Destroy the cowboy that was hit
            Destroy(other.gameObject);
            
            // Destroy the projectile itself so it doesn't fly through more cowboys
            Destroy(gameObject);
        }
    }
}