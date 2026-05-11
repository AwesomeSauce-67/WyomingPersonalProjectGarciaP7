using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealthDamage playerScript;
    public GameObject playerPrefab;
    public GameObject deathUI;
    public Vector3 spawnPoint = new Vector3(0, 5, 0);
    public bool paused;
    public GameObject pauseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.deathStatus == true)
        {
            deathUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(playerPrefab, spawnPoint
                    , Quaternion.identity);

                deathUI.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
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
}
