using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealthDamage playerScript;
    public GameObject playerPrefab;
    public GameObject deathUI;
    public Vector3 spawnPoint = new Vector3(0, 5, 0);

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
    }
}
