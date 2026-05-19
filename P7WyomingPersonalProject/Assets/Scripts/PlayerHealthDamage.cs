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

    public UIHealthBar healthBar;


    void Start()
    {
        StartCoroutine(HealOverTime());
    }
    void Update()
    {
        timer += Time.deltaTime;

    }
       
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && timer >= 5)
        {
            EnemyAI hitEnemy = other.GetComponent<EnemyAI>();

            if (hitEnemy != null )
            {
                health = Mathf.Max(0, health - 10f);
            }
            timer = 0;

            if (healthBar != null)
            {
                healthBar.UpdateHealthDisplay(health, maxHealth);
            }

        }
    }
    IEnumerator HealOverTime()
{
    while (true)
    {
   
        yield return new WaitForSeconds(timeUntilHeal);

        
        if (health < maxHealth && timer >= 5) 
        {
            health += healAmount;
  
            health = Mathf.Min(health, maxHealth);
            Debug.Log("CurrentHealth: " + health);
        }

            if (healthBar != null)
            {
                healthBar.UpdateHealthDisplay(health, maxHealth);
            }
        }
}

   

} 
