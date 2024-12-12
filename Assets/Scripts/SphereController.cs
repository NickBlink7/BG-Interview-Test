using UnityEngine;

public class SphereController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 5f;

    [Header("Input Settings")]
    public string horizontalInputAxis = "Horizontal";
    public string verticalInputAxis = "Vertical";

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on the sphere! Please add one.");
        }
    }

    private void FixedUpdate()
    {
        // Get player input
        float moveX = Input.GetAxis(horizontalInputAxis);
        float moveZ = Input.GetAxis(verticalInputAxis);

        // Calculate the direction to apply force
        Vector3 forceDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (forceDirection != Vector3.zero)
        {
            // Apply force to move the sphere
            Vector3 force = forceDirection * moveForce;
            rb.AddForce(force, ForceMode.Force);

            // Limit the sphere's speed
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }
}
