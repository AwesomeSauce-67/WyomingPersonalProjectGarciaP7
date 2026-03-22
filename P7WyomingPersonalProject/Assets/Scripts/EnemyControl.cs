using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    public float enemyHealth = 50.0f;
    public float damage = 5.0f;
    public PlayerHealthDamage playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerScript = playerObj.GetComponent<PlayerHealthDamage>();
        }
    }

    void Update()
    {
        if (enemyHealth <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
           enemyHealth -= damage;
        }
        if (other.CompareTag("Projectile2"))
        {
           enemyHealth -= damage * 5f;
        }
        if (other.CompareTag("Player"))
        {
            playerScript.health -= 5.0f;
        }
    }
}
