using UnityEngine;

public class LimbHitDetector : MonoBehaviour
{
    // In the Inspector, type "rightarm", "leftarm", etc.
    public string limbName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION DETECTED ON: " + limbName);

        if (ArduinoManager.Instance != null)
        {
            ArduinoManager.Instance.SendHit(limbName);
        }

        // Destroy the bullet so it doesn't hit twice
        Destroy(other.gameObject);
    }
}