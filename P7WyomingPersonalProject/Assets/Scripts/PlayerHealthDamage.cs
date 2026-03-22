using System.Collections;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float healAmount = 5;
    public float healInterval = 1;

    public bool deathStatus = false;

    public float timer;

    public float timeUntilHeal;

    void Start()
    {
        InvokeRepeating("PassiveHeal", 0.0f, timeUntilHeal);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (health <= 0)
        {
            deathStatus = true;
            Destroy(gameObject);
        }
    }
       
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && timer >= 5)
        {
            timer = 0;
           
        }
    }
    void PassiveHeal()
    {
        if (health < maxHealth && timer >= 5)
        {
            health += 5.0f;
        }
        
    }
   
   
       
} 
