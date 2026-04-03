using UnityEngine;

public class BallBullet : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 targetDirection;

    void Start()
    {
        GameObject body = GameObject.Find("BodyCollider");

        if (body != null && body.transform.childCount > 0)
        {

            int randomIndex = Random.Range(0, body.transform.childCount);
            Transform randomLimb = body.transform.GetChild(randomIndex);

            // Set the target to the LIMB position
            Vector3 targetPos = randomLimb.position;

            // Calculate direction
            targetDirection = (targetPos - transform.position).normalized;

            // Look at the target
            transform.forward = targetDirection;

            Debug.Log("Aiming at limb: " + randomLimb.name);
        }
        else
        {
            // If it can't find limbs, just move forward so it doesn't sit still
            Debug.LogError("BodyCollider or Limbs not found! Check your Hierarchy naming.");
            targetDirection = transform.forward;
        }

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Move in the direction set at Start
        transform.position += targetDirection * speed * Time.deltaTime;
    }

}