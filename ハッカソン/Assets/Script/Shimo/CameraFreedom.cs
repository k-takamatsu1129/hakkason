using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFreedom : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float sensitivity = 1f;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        transform.Translate( new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, moveInput.y * moveSpeed));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, moveSpeed, rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, moveSpeed*-1, rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        }
    }

    private void Look()
    {
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
