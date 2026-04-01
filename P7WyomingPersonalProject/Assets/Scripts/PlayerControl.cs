using Unity.Mathematics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float gravityModifier;
    public GameObject projectilePrefab;
    public GameObject critProjectilePrefab;
    public Transform projectileSpawnPoint;
    public float ammo = 50.0f;
    public bool grounded;
    public bool startUp;
    private Rigidbody rb;
    public float jumpForce=10;
    private Vector3 movement;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       //Physics.gravity *= gravityModifier;
        startUp = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        movement = (transform.forward * v + transform.right * h).normalized * speed;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }

        if (Input.GetMouseButtonDown(0) && ammo > 0 && !startUp)
        {
            Quaternion spawnRot = transform.rotation * projectilePrefab.transform.rotation;
            Instantiate(projectilePrefab, projectileSpawnPoint.position, spawnRot);
            ammo -= 1;
        }

        if (Input.GetMouseButtonDown(1) && ammo >= 10 && !startUp)
        {
            Quaternion spawnRot = transform.rotation * critProjectilePrefab.transform.rotation;
            Instantiate(critProjectilePrefab, projectileSpawnPoint.position, spawnRot);
            ammo -= 10;
        }
    }
    void FixedUpdate()
    {
        float currentYVelocity = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(movement.x, currentYVelocity, movement.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
    }   }
}
