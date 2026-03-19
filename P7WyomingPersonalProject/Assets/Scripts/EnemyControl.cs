using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    public float health = 50.0f;
    public float damage = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
           health -= damage;
        }
        if (other.CompareTag("Projectile2"))
        {
                health -= damage * 5f;
        }
    }
}
