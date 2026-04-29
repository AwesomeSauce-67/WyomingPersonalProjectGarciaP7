using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public float ammoRefill = 0.0f;
    public PlayerControl playerControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl pc = other.GetComponent<PlayerControl>();
             pc.ammo += ammoRefill;
             Destroy(gameObject);
            Debug.Log("CurrentAmmo: " + pc.ammo );


        }
    }
}
