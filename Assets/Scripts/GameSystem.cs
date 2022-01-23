using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{   
    public GameObject enemyPrefab;
    [SerializeField]
    public int targetEnemiesCount;
    public int currentEnemiesCount;
    public int enemiesKilled = 0;
    public Vector3 size;
    public Vector3 spawnPosition;
    public Text enemiesKilledText;

    void Start()
    {
        currentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        InvokeRepeating("SpawnEnemy", 0f, 5f);
    }

    private void Update()
    {
        enemiesKilledText.text = enemiesKilled.ToString();
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }*/

    private void SpawnEnemy() {
        if (currentEnemiesCount < targetEnemiesCount) {
            spawnPosition = transform.position;
            spawnPosition.y = 0.1f;
            spawnPosition = spawnPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                0.1f, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemiesCount++;
        }
    }
}
