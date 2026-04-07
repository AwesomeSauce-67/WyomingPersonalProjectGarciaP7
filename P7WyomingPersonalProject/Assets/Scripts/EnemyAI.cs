using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float detectionRange = 10.0f;
    public float stopDistance = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,
            transform.rotation.eulerAngles.y, 0);

        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("ENEMY ERROR: I can't find anything tagged 'Player'!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
      
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange && distance > stopDistance)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position,
                moveSpeed * Time.deltaTime);
        }
    }
}
