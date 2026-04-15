using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ArduinoManager : MonoBehaviour
{
    public static ArduinoManager Instance;
    private string esp32IP = "192.168.4.1";

    // --- INVINCIBILITY SETTINGS ---
    private bool isInvincible = false;
    [SerializeField] private float invincibilityDuration = 2.0f;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void SendHit(string limbName)
    {
        // If we are currently in the 2-second cooldown, ignore the hit
        if (isInvincible)
        {
            Debug.Log("Hit ignored: Player is currently invincible.");
            return;
        }

        // Start the cooldown and send the data
        StartCoroutine(HitSequence(limbName));
    }

    IEnumerator HitSequence(string limbName)
    {
        isInvincible = true; // Lock the gate
        Debug.Log("HIT REGISTERED: Starting 2s cooldown.");

        // Send the web request to the ESP32
        StartCoroutine(PostHit(limbName));

        // Wait for the duration
        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false; // Unlock the gate
        Debug.Log("Invincibility worn off. Ready for next hit.");
    }

    IEnumerator PostHit(string limbName)
    {
        WWWForm form = new WWWForm();
        form.AddField("limb", limbName);

        using (UnityWebRequest www = UnityWebRequest.Post("http://" + esp32IP + "/hit", form))
        {
            // We use a timeout so Unity doesn't hang if the ESP32 is off
            www.timeout = 1;
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogWarning("ESP32 Connection Failed: " + www.error);
            }
        }
    }
}