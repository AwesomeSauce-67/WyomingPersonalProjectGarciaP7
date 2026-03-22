using System.Collections;
using UnityEngine;

public class PlayerHealthDamage : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float healAmount = 5;
    public float healInterval = 1;

    public bool deathStatus = false;

    public float timer = 5.0f;
    public int seconds;

    public float timeUntilHeal;

    void Start()
    {
        InvokeRepeating("PassiveHeal", 0.0f, timeUntilHeal);
    }
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;

        if (health <= 0)
        {
            deathStatus = true;
            Destroy(gameObject);
        }
    }
       
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && seconds <= 5)
        {
            seconds = 0;
        }
    }
    void PassiveHeal()
    {
        if (health < maxHealth && seconds >= 5)
        {
            timer = 0;
            health += 5.0f;
        }
        
    }
   
   
       
} 
