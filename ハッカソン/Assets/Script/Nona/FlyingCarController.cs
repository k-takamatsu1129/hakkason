using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingCarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    public float ascentSpeed = 20f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private float upDown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        // ì¸óÕÇæÇØéÊìæ
        moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) moveInput.y = 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y = -1;

        if (Keyboard.current.aKey.isPressed) moveInput.x = -1;
        if (Keyboard.current.dKey.isPressed) moveInput.x = 1;

        upDown = 0;
        if (Keyboard.current.spaceKey.isPressed) upDown = 1;
        if (Keyboard.current.leftShiftKey.isPressed) upDown = -1;
    }

    void FixedUpdate()
    {
        // ï®óùèàóùÇÕÇ±Ç±
         if (rb == null) return; // ï€åØ Vector3 pos = rb.position;
        rb.MovePosition(rb.position + transform.forward * moveInput.y * moveSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, moveInput.x * rotationSpeed * Time.fixedDeltaTime, 0));
        rb.AddForce(Vector3.up * upDown * ascentSpeed, ForceMode.Acceleration);
    }
}

