using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3 (0, 0, 0);
    public float sensitivity = 0.2f;
    public float smoothSpeed = 0.125f;

    private float pitch = 0f;
    private float yaw = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        pitch = angles.x;
        yaw = angles.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;

       
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -20f, 60f);

        player.rotation = Quaternion.Euler(0, yaw, 0);
        
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPosition = player.position + (rotation * offset);

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
