using Unity.Mathematics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public GameObject projectilePrefab;
    public GameObject critProjectilePrefab;
    public Transform projectileSpawnPoint;
    public float ammo = 50.0f;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
 horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Quaternion spawnRot = transform.rotation * projectilePrefab.transform.rotation;
            Instantiate(projectilePrefab, projectileSpawnPoint.position, spawnRot);
            ammo -= 1;
        }
        if (Input.GetMouseButtonDown(1) && ammo >= 10)
        {
            Quaternion spawnRot = transform.rotation * critProjectilePrefab.transform.rotation;
            Instantiate(critProjectilePrefab, projectileSpawnPoint.position, spawnRot);
            ammo -= 10;
        }
    }
      
}
