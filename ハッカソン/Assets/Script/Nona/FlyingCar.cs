using UnityEngine;



public class FlyingCar : MonoBehaviour
{
    public float targetHeight = 5.0f;
    public float liftForce = 5.0f;
    public float acceleration = 8.0f;
    public float maxSpeedKmh = 80.0f;

    private Rigidbody rb;
    private float maxSpeedMs;
    private bool hasLifted = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        maxSpeedMs = maxSpeedKmh / 3.6f;
    }

    void FixedUpdate()
    {
        if (!hasLifted)
        {
            rb.AddForce(Vector3.up * liftForce, ForceMode.Acceleration);

            if (transform.position.y >= targetHeight)
            {
                hasLifted = true;
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            }
        }
        else
        {
            rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
        }
    }
}
