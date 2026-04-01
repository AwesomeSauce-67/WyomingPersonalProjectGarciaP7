using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] ammoPrefabs;
    public float spawnRangeX = 20;
    public float spawnPosZ = 20;
    public float startDelay = 2;
    public float enemyInterval = 10.0f;
    public float ammoInterval = 7.5f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay,enemyInterval);
        InvokeRepeating("SpawnAmmoPack", startDelay , ammoInterval);

    }

    // Update is called once per frame
    void Update()
    {


    }
    void SpawnEnemy()
    {

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
             0, Random.Range(-spawnPosZ, spawnPosZ));
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
            enemyPrefabs[enemyIndex].transform.rotation);

    }
    void SpawnAmmoPack()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 
            0, Random.Range(-spawnPosZ, spawnPosZ));
        int AmmoPackIndex = Random.Range(0, ammoPrefabs.Length);
        Instantiate(ammoPrefabs[AmmoPackIndex], spawnPos,
            ammoPrefabs[AmmoPackIndex].transform.rotation);

    }

}
