using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float sensitivity = 0.2f;
    public float smoothSpeed = 0.125f;
    public float verticalFocusOffset = 1.5f; 

    private float pitch = 0f;
    private float yaw = 0f;

    void Start()
    {
        ToggleCursor(true);
        Vector3 angles = transform.eulerAngles;
        pitch = angles.x;
        yaw = angles.y;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) ToggleCursor(false);
        if (Mouse.current.leftButton.wasPressedThisFrame && Cursor.lockState != CursorLockMode.Locked) ToggleCursor(true);
    }

    void LateUpdate()
    {
        if (player == null || Cursor.lockState != CursorLockMode.Locked) return;

      
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -20f, 60f);

      
        player.rotation = Quaternion.Euler(0, yaw, 0);

       
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPosition = player.position + (rotation * offset);

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

       
        Vector3 focusPoint = player.position + Vector3.up * verticalFocusOffset;
        transform.LookAt(focusPoint);
    }

    void ToggleCursor(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }
}
