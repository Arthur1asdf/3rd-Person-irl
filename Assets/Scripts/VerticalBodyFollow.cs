using UnityEngine;

public class VerticalBodyFollow : MonoBehaviour
{
    [Header("Reference to the Head")]
    public Transform headCamera;

    void Update()
    {
        if (headCamera == null) return;

        // 1. Follow the head's position exactly
        transform.position = headCamera.position;

        // 2. Only follow the head's 'Y' rotation (looking left/right)
        // This keeps the boxes from tilting when you look up/down
        Vector3 headEuler = headCamera.eulerAngles;
        transform.rotation = Quaternion.Euler(0, headEuler.y, 0);
    }
}