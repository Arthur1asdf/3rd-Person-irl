using UnityEngine;

public class LimbHitDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("MY LIMB GOT HIT: " + gameObject.name);

        // desroy bullet
        Destroy(other.gameObject);
    }
}