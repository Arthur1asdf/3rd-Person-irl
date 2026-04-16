using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ArduinoManager : MonoBehaviour
{
    public static ArduinoManager Instance;

    [SerializeField] private string esp32IP = "192.168.4.1";
    [SerializeField] private float hitCooldown = 2f;

    private float lastHitTime = -999f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SendHit(string limbName)
    {
        if (Time.time - lastHitTime < hitCooldown)
        {
            Debug.Log("Hit ignored due to global cooldown");
            return;
        }

        lastHitTime = Time.time;
        StartCoroutine(PostHit(limbName));
    }

    IEnumerator PostHit(string limbName)
    {
        string url = "http://" + esp32IP + "/hit?zone=" + UnityWebRequest.EscapeURL(limbName);

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Unity Error: " + www.error);
        }
        else
        {
            Debug.Log("Unity Success: Sent " + limbName);
            Debug.Log("ESP32 Response: " + www.downloadHandler.text);
        }
    }
}