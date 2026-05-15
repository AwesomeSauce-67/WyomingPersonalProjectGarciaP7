using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealthDamage pHD;
    public PlayerControl pC;
    public CameraControls cC;
    public GameObject playerPrefab;
    public Vector3 spawnPoint = new Vector3(0, 5, 0);
    public bool paused;
    public GameObject pauseScreen;
    public GameObject deathUI;
    public GameObject player;
    public Button respawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawn.onClick.AddListener(Respawn);
    }

    // Update is called once per frame
    void Update()
    {
        if (pHD.health <= 0)
        {
            Death();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
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

    void Death()
    {
        pHD.deathStatus = true;
        deathUI.SetActive(true);
        player.SetActive(false);
        cC.ToggleCursor(true);
    }

    void Respawn()
    {
        player.SetActive(true);
        deathUI.SetActive(false);
        player.transform.position = spawnPoint;
        pHD.health = 50;
        pC.ammo = 0;
    }

}
