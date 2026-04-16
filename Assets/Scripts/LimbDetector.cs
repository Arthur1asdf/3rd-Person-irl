using UnityEngine;

public class LimbHitDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet"))
            return;

        string limbName = gameObject.name.ToLower();

        if (limbName != "leftleg" &&
            limbName != "leftarm" &&
            limbName != "rightarm" &&
            limbName != "rightleg")
        {
            Debug.LogWarning("Unknown limb object name: " + gameObject.name);
            return;
        }

        Debug.Log("COLLISION DETECTED ON: " + limbName);

        if (ArduinoManager.Instance != null)
        {
            ArduinoManager.Instance.SendHit(limbName);
        }

        Destroy(other.gameObject);
    }
}