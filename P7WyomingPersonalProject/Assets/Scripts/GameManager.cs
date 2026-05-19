
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealthDamage pHD;
    public PlayerControl pC;
    public GameObject playerPrefab;
    public Vector3 spawnPoint = new Vector3(0, 5, 0);
    public bool paused;
    public GameObject pauseScreen;
    public GameObject deathUI;
    public GameObject player;
   
    public bool dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pHD.health <= 0 && !dead)
        {
            Death();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Respawn();
        }
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void Death()
    {
        dead = true;
        pHD.deathStatus = true;
        deathUI.SetActive(true);
        player.SetActive(false);
        
    }

    void Respawn()
    {
        
        dead = false;
        player.transform.position = spawnPoint;
        pHD.health = 50;
        pC.ammo = 0;
        player.SetActive(true);
        deathUI.SetActive(false);
        
        
        if (pHD.healthBar != null)
        {
            pHD.healthBar.UpdateHealthDisplay(pHD.health, pHD.maxHealth);
        }

    }

}
