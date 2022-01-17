using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{   
    public GameObject enemyPrefab;
    [SerializeField]
    public int targetEnemiesCount;
    public int currentEnemiesCount;
    public Vector3 size;
    public Vector3 spawnPosition;

    void Start()
    {
        currentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

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
