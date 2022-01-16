using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{   
    public GameObject enemyPrefab;
    public int enemiesCount;
    public Vector3 center;
    public Vector3 size;
    public Vector3 spawnPosition;

    void Start()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        InvokeRepeating("SpawnEnemy", 0f, 3f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(center, size);
    }

    private void SpawnEnemy() {
        if (enemiesCount < 5) { 
            spawnPosition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                0.1f, Random.Range(-size.z / 2, size.z / 2));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemiesCount++;
        }
    }
}
