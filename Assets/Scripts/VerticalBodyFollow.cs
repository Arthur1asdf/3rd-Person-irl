using UnityEngine;

public class VerticalBodyFollow : MonoBehaviour
{
    [Header("Reference to the Head")]
    public Transform headCamera;
    public float bodyHeightOffset = 1.2f; // tweak this

    void Update()
    {
        if (headCamera == null) return;

        Vector3 headPos = headCamera.position;

        // Move body DOWN from head
        transform.position = new Vector3(
            headPos.x,
            headPos.y - bodyHeightOffset,
            headPos.z
        );

        Vector3 headEuler = headCamera.eulerAngles;
        transform.rotation = Quaternion.Euler(0, headEuler.y, 0);
    }
}